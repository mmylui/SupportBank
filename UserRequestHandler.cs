class UserRequestHandler
{
    private AccountManager AccountManager;
    private TransactionManager TransactionManager;
    public UserRequestHandler(AccountManager accountManager, TransactionManager transactionManager)
    {
        AccountManager = accountManager;
        TransactionManager = transactionManager;
    }

    public void HandleListAll()
    {
        AccountManager.PrintAccountBalances();
    }

    public void HandleListAccount(string accountName)
    {
        AccountManager.PrintAccountTransactions(accountName);
    }

}