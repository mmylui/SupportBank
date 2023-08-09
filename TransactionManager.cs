class TransactionManager
{
    public List<Transaction> Transactions
    { get; }
    public AccountManager AccountManager { get; }

    public TransactionManager(AccountManager accountManager)
    {
        Transactions = new List<Transaction>();
        AccountManager = accountManager;
    }


    public void MakeTransactions(List<TransactionString> transactionStrings)
    {
        foreach (TransactionString transactionString in transactionStrings)
        {
            var newTransaction = new Transaction(transactionString, AccountManager);
            ProcessTransaction(newTransaction);
        }

    }

    public void ProcessTransaction(Transaction transaction){
        Transactions.Add(transaction);
        transaction.To.ReceiveMoney(transaction);
        transaction.From.SendMoney(transaction);
    }

    public void PrintAllTransactions()
    {
        Console.WriteLine("Printing all transactions:");
        foreach (Transaction transaction in Transactions)
        {
            transaction.PrintTransaction();
        }
    }

}