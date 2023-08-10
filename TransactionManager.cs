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

    public List<int> ValidateTransactions(List<TransactionString> transactionStrings)
    {
        List<int> invalidIndexes = new List<int>();
        TransactionValidator transactionValidator = new TransactionValidator();

        for (int i = 0; i < transactionStrings.Count; i ++)
        {
            if (!transactionValidator.IsValidTransaction(transactionStrings[i]))
            {
                invalidIndexes.Add(i);
            }
        }
        
        return invalidIndexes;
    }

    public void MakeTransactions(List<TransactionString> transactionStrings)
    {   TransactionValidator transactionValidator = new TransactionValidator();

        foreach (TransactionString transactionString in transactionStrings)
        {
            if (transactionValidator.IsValidTransaction(transactionString))
            {
                var newTransaction = new Transaction(transactionString, AccountManager);
                ProcessTransaction(newTransaction);
            }
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