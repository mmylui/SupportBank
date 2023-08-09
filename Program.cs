CSVReader line = new CSVReader();
List<TransactionString> transactionStrings = line.GetTransactionStrings();
AccountManager accountManager= new AccountManager();
TransactionManager transactionManager = new TransactionManager(accountManager);
transactionManager.MakeTransactions(transactionStrings);
// transactionManager.PrintAllTransactions();

// accountManager.PrintAccountBalances();

UserRequestHandler userRequestHandler= new UserRequestHandler(accountManager, transactionManager);

Console.WriteLine("Enter command:\n'List All' - Show All Account Balances.\n'List Account' - Lets you specify a user to view");
string userCommand = Console.ReadLine();
if(userCommand != null){
    userRequestHandler.HandleRequest(userCommand);
}


