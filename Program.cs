CSVReader line = new CSVReader();
List<TransactionString> transactionStrings = line.GetTransactionStrings();
TransactionManager transactionManager = new TransactionManager();
transactionManager.MakeTransactions(transactionStrings);
transactionManager.PrintAllTransactions();
Console.ReadLine();


