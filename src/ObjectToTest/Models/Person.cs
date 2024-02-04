namespace ObjectToTest.Models;

public abstract class Person
{
    public IList<Debts>? Debts { get; set; }
    public abstract void AddDebt(Debts debt);

    protected decimal SumVigent()
        => this.Debts!.Where(dbt => dbt.IsVigent).Sum(x => x.Cost);
}
