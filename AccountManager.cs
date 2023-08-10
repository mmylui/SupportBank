using NLog;


class AccountManager
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public List <Account> Accounts
    { get; set; }

    public AccountManager(){
        Accounts = new List<Account>();
    }
    public Account GetAccountByIndex(int accountIndex)
    {
        return Accounts[accountIndex];
    }

    public int GetAccountIndex(string name)
    {
        return Accounts.FindIndex(account => account.Name == name);
    }

    public int CreateAccount(string name)
    {
            Accounts.Add(new Account (name));
            return Accounts.Count - 1;
    }

    public Account GetAccountForTransaction (string name)
    {
        int accountIndex = GetAccountIndex(name);
        if (accountIndex == -1)
        {
            accountIndex = CreateAccount(name);
        }
        return GetAccountByIndex (accountIndex);
    }

    public void PrintAccountTransactions(string name)
    {
        Logger.Info($"Finding account for {name}");

        int accountIndex = GetAccountIndex(name);
        if (accountIndex == -1)
        {
            Logger.Info($"{name} doesn't have account");
            Console.WriteLine("This account does not exist.");
        } else
        {
            Logger.Info($"Found account for {name}");
            var account = GetAccountByIndex(accountIndex);
            account.PrintAccount();
        }
    }

    public void PrintAccountBalances(){
        Logger.Info($"Printing Account Balances");

        Console.WriteLine("Account Balances:");
        foreach (Account account in Accounts){
            account.PrintBalance();
        }
    }


}