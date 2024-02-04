namespace ObjectToTest.Models;

public class CorporateEntity : Person, IFinancialMoment
{
    private readonly decimal? balance;

    public CorporateEntity(decimal value)
    {
        this.Debts = new List<Debts>();
        this.balance = value;
    }

    public override void AddDebt(Debts debt)
    {
        this.Debts!.Add(debt);
    }
    
    public decimal CreditLimit(decimal tax)
    {
        if (HasFinanciallyRestricted())
        {
            return 0M;
        }

        return (this.balance!.Value - this.SumVigent()) * tax;
    }

    public bool HasFinanciallyRestricted()
    {
        if (this.Debts!.Count > 0)
        {
            if (!this.Debts!.Any(dbt => dbt.IsVigent && (dbt.Cost >= this.balance * 2M)))
            {
                return true;
            }

            var sum = this.Debts!.Where(dbt => dbt.IsVigent).Sum(x => x.Cost);

            return (sum > this.balance);
        }

        return false;
    }

    public decimal BringFunds()
    {
        return balance ?? 0M;
    }

    public void RegisterDebts(decimal debts)
    {
        if (debts <= 0)
        {
            throw new ArgumentException("The debts is not eligible for this loan.");
        }

        if (HasFinanciallyRestricted())
        {
            throw new ArgumentOutOfRangeException("The individual is not eligible for this loan.");
        }

        this.Debts!.Add(new Models.Debts
        {
            IsVigent = true,
            Cost = debts
        });
    }
}
