class UserRequestHandler
{
    private AccountManager AccountManager;
    private TransactionManager TransactionManager;
    public UserRequestHandler(AccountManager accountManager, TransactionManager transactionManager)
    {
        AccountManager = accountManager;
        TransactionManager = transactionManager;
    }

    public void HandleRequest(string request)
    {
        switch (request)
        {
            case "List All":
                AccountManager.PrintAccountBalances();
                break;
            case "List Account":
                Console.Write("Enter Name: ");
                string accountName = Console.ReadLine();
                AccountManager.PrintAccountTransactions(accountName);
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }

    }

}