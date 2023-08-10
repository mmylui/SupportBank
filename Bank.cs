using NLog;

class Bank
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

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
        Logger.Info("Initialising the Bank");


        List<TransactionString> transactionStrings = CSVReader.GetTransactionStrings();

        List<string> errorMessages = TransactionManager.ValidateTransactions(transactionStrings);

        if (errorMessages.Count > 0){
            PrintInvalidTransactions(errorMessages);
            Console.WriteLine("Do you want to continue? Invalid Transactions will not be processed.\nType 'Quit' to exit the program or press Enter to continue");
            string userErrorResponse = Console.ReadLine();
            Logger.Info($"Invalid lines in file. User entered {userErrorResponse}");

            if(userErrorResponse == "Quit"){
                Logger.Info($"Quitting Program from user response");
                return false;
            }
            Console.WriteLine("Continuing...\n");
        }

        TransactionManager.MakeTransactions(transactionStrings);
        Logger.Info("Bank Setup Complete");

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