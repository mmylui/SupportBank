using NLog;
class Account
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public string Name { get; }
    public decimal Balance;
    public List<Transaction> AccountTransactions;

    public Account(string name)
    {
        Name = name;
        Balance = 0;
        AccountTransactions = new List<Transaction>();
    }

    public void ReceiveMoney(Transaction transaction)
    {
        AccountTransactions.Add(transaction);
        Balance += transaction.Amount;
    }
    public void SendMoney(Transaction transaction)
    {
        AccountTransactions.Add(transaction);
        Balance -= transaction.Amount;
    }

    public void PrintAccount()
    {
        Logger.Info($"Printing transactions for {Name}:");

        Console.WriteLine($"Printing transactions for {Name}:");
        foreach (Transaction transaction in AccountTransactions)
        {
            transaction.PrintTransaction();
        }
        Console.WriteLine($"Balance: £{Balance}");
    }

    public void PrintBalance()
    {
        if (Balance < 0)
        {
            Console.WriteLine($"\tName: {Name}\tBalance: -£{Balance*-1}");
        }
        else
        {

            Console.WriteLine($"\tName: {Name}\tBalance: £{Balance}");
        }
    }
}