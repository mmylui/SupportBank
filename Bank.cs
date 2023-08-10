using NLog;

class Bank
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    private AccountManager AccountManager;
    private TransactionManager TransactionManager;
    public UserRequestHandler UserRequestHandler
    { get; }

    public Bank()
    {
        AccountManager = new AccountManager();
        TransactionManager = new TransactionManager(AccountManager);
        UserRequestHandler = new UserRequestHandler(AccountManager, TransactionManager);
    }

    public bool SetupBank(string fileName){

        // string[] splitFilename = fileName.Split('.');
        string extension = fileName.Split('.')[^1];

        Console.WriteLine("Initialising the bank...");
        Logger.Info("Initialising the Bank");

        List<TransactionString> transactionStrings = new List<TransactionString>();

        if(extension == "csv"){
            Logger.Info($"Parsing CSV file");
            CSVReader csvReader = new CSVReader();
            transactionStrings = csvReader.GetTransactionStrings(fileName);
        } else if (extension == "json"){
            Logger.Info($"Parsing JSON file");
            JSONReader jsonReader = new JSONReader();
            transactionStrings = jsonReader.GetTransactionStrings(fileName);
        } else{
            Logger.Error($"Invalid File Extension");
            throw new Exception("Invalid file extension");
        }


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