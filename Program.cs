CSVReader line = new CSVReader();
List<TransactionString> transactionStrings = line.GetTransactionStrings();
AccountManager accountManager= new AccountManager();
TransactionManager transactionManager = new TransactionManager(accountManager);
transactionManager.MakeTransactions(transactionStrings);
// transactionManager.PrintAllTransactions();

Account firstAccount = accountManager.GetAccountByName("Ben B");
firstAccount.PrintAccount();


Console.ReadLine();


