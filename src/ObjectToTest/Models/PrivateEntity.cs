namespace ObjectToTest.Models;

public class PrivateEntity : Person, IFinancialMoment
{
    private readonly decimal? salary;

    public PrivateEntity(decimal value)
    {
        this.Debts = new List<Debts>();
        this.salary = value;
    }

    public override void AddDebt(Debts debt)
    {
        this.Debts!.Add(debt);
    }

    public decimal BringFunds()
    {
        return salary ?? 0M;
    }

    public decimal CreditLimit(decimal tax)
    {
        if (HasFinanciallyRestricted())
        {
            return 0M;
        }

        return (this.salary!.Value - this.SumVigent()) * tax;
    }

    public bool HasFinanciallyRestricted()
    {
        if (this.Debts!.Count > 0)
        {
            var sum = this.SumVigent();

            return (sum > 5 * this.salary);
        }
        return false;
    }

    public void RegisterDebts(decimal debts)
    {
        this.Debts!.Add(new Models.Debts
        {
            IsVigent = true,
            Cost = debts
        });
    }
}
