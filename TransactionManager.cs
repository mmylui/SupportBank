class TransactionManager
{
    public List<Transaction> Transactions
    { get; }

    public TransactionManager()
    {
        Transactions = new List<Transaction>();
    }


    public void MakeTransactions(List<TransactionString> transactionStrings)
    {
        foreach (TransactionString transactionString in transactionStrings)
        {
            var newTransaction = new Transaction(transactionString);
            Transactions.Add(newTransaction);
        }

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