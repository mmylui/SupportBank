CSVReader line = new CSVReader();
List<TransactionString> transactionStrings = line.GetTransactionStrings();
AccountManager accountManager= new AccountManager();
TransactionManager transactionManager = new TransactionManager(accountManager);
transactionManager.MakeTransactions(transactionStrings);
transactionManager.PrintAllTransactions();
Console.ReadLine();


