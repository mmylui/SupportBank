class Bank
{
    private CSVReader CSVReader;
    private AccountManager AccountManager;
    private TransactionManager TransactionManager;
    public UserRequestHandler UserRequestHandler
    { get; }

    public Bank()
    {
        CSVReader = new CSVReader();
        List<TransactionString> transactionStrings = CSVReader.GetTransactionStrings();
        AccountManager = new AccountManager();
        TransactionManager = new TransactionManager(AccountManager);
        List<int> invalidIndexes = TransactionManager.ValidateTransactions(transactionStrings);
        if (invalidIndexes.Count > 0){
            PrintInvalidTransactions(invalidIndexes, transactionStrings);
        }
        TransactionManager.MakeTransactions(transactionStrings);

        UserRequestHandler = new UserRequestHandler(AccountManager, TransactionManager);
    }

    private void PrintInvalidTransactions(List<int> invalidIndexes, List<TransactionString> transactionStrings)
    {
        foreach(int invalidIndex in invalidIndexes)
        {
            Console.WriteLine($"Invalid transaction at line {invalidIndex + 2}");
        }
    }
}