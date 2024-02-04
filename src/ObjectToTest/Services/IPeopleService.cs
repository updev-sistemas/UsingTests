using ObjectToTest.Models;

namespace ObjectToTest.Services
{
    public interface IPeopleService
    {
        bool ApproveLoan(IFinancialMoment person, decimal amount);
        decimal GetLimit(IFinancialMoment person);
        void RegisterLoan(IFinancialMoment person, decimal amount);
    }
}