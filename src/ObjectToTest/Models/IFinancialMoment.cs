namespace ObjectToTest.Models;

public interface IFinancialMoment
{
    decimal BringFunds();
    bool HasFinanciallyRestricted();
    decimal CreditLimit(decimal tax);
    void RegisterDebts(decimal debts);
}
