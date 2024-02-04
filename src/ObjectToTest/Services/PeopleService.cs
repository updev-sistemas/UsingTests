using ObjectToTest.Models;

namespace ObjectToTest.Services;

public class PeopleService : IPeopleService
{
    public void RegisterLoan(IFinancialMoment person, decimal amount)
    {
        person.RegisterDebts(amount);
    }

    public bool ApproveLoan(IFinancialMoment person, decimal amount)
    {
        decimal? limit = GetLimit(person);

        bool flag1 = limit <= amount;
        bool flag2 = person.HasFinanciallyRestricted();

        return flag1 && flag2;
    }

    public decimal GetLimit(IFinancialMoment person) => person switch
    {
        CorporateEntity cEntity => cEntity.CreditLimit(1.4M),
        PrivateEntity pEntity => pEntity.CreditLimit(0.6M),
        _ => 0M,
    };
}
