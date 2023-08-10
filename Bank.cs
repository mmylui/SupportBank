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
        AccountManager = new AccountManager();
        TransactionManager = new TransactionManager(AccountManager);
        UserRequestHandler = new UserRequestHandler(AccountManager, TransactionManager);
    }

    public bool SetupBank(){

        Console.WriteLine("Initialising the bank...");

        List<TransactionString> transactionStrings = CSVReader.GetTransactionStrings();

        List<string> errorMessages = TransactionManager.ValidateTransactions(transactionStrings);

        if (errorMessages.Count > 0){
            PrintInvalidTransactions(errorMessages);
            Console.WriteLine("Do you want to continue? Invalid Transactions will not be processed.\nType 'Quit' to exit the program or press Enter to continue");
            string userErrorResponse = Console.ReadLine();
            if(userErrorResponse == "Quit"){
                return false;
            }
            Console.WriteLine("Continuing...\n");
        }



        TransactionManager.MakeTransactions(transactionStrings);
        return true;

    }

    private void PrintInvalidTransactions(List<string> errorMessages)
    {
        foreach(string errorMessage in errorMessages)
        {
            Console.WriteLine(errorMessage);
        }
    }
}