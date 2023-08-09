class AccountManager
{
    public List <Account> Accounts
    { get; set; }

    public AccountManager(){
        Accounts = new List<Account>();
    }
    public Account GetAccountByName(string name)
    {
        int accountIndex = Accounts.FindIndex(account => account.Name == name);
        if(accountIndex == -1) {
            Accounts.Add(new Account (name));
            accountIndex = Accounts.Count - 1;
        }
        return Accounts[accountIndex];
    }

    public void PrintAccountBalances(){
        Console.WriteLine("Account Balances:");
        foreach (Account account in Accounts){
            account.PrintBalance();
        }
    }

    
}