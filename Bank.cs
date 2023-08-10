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
        TransactionManager.MakeTransactions(transactionStrings);

        UserRequestHandler = new UserRequestHandler(AccountManager, TransactionManager);
    }
}