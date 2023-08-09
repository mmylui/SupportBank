class Account
{
    public string Name;
    public decimal Balance;
    public List<Transaction> AccountTransactions;

    public Account(string name)
    {
        Name = name;
        Balance = 0;
        AccountTransactions = new List<Transaction>();
    }
}