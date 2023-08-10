class AccountManager
{
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
        int accountIndex = GetAccountIndex(name);
        if (accountIndex == -1)
        {
            Console.WriteLine("This account does not exist.");
        } else
        {
            var account = GetAccountByIndex(accountIndex);
            account.PrintAccount();
        }
    }

    public void PrintAccountBalances(){
        Console.WriteLine("Account Balances:");
        foreach (Account account in Accounts){
            account.PrintBalance();
        }
    }


}