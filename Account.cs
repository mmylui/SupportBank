class Account
{
    public string Name { get; }
    public decimal Balance;
    public List<Transaction> AccountTransactions;

    public Account(string name)
    {
        Name = name;
        Balance = 0;
        AccountTransactions = new List<Transaction>();
    }

    public void ReceiveMoney(Transaction transaction){
        AccountTransactions.Add(transaction);
        Balance += transaction.Amount;
    }
    public void SendMoney(Transaction transaction){
        AccountTransactions.Add(transaction);
        Balance -= transaction.Amount;
    }

    public void PrintAccount(){
        Console.WriteLine($"Printing transactions for {Name}:");
        foreach (Transaction transaction in AccountTransactions)
        {
            transaction.PrintTransaction();
        }
        Console.WriteLine($"Balance: {Balance}");
    }
}