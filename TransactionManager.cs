class TransactionManager
{
    public List<Transaction> Transactions
    { get; }
    public AccountManager AccountManager { get; }

    public TransactionManager(AccountManager accountManager)
    {
        Transactions = new List<Transaction>();
        AccountManager = accountManager;
    }

    public List<string> ValidateTransactions(List<TransactionString> transactionStrings)
    {
        List<string> invalidErrorMessages = new List<string>();
        TransactionValidator transactionValidator = new TransactionValidator();

        for (int i = 0; i < transactionStrings.Count; i ++)
        {
            ValidationResponse validationResponse = transactionValidator.ReturnValidationResponse(transactionStrings[i], i + 2);

            if (!validationResponse.IsValid)
            {
                invalidErrorMessages.Add(validationResponse.ErrorMessage);
            }
        }
        
        return invalidErrorMessages;
    }

    public void MakeTransactions(List<TransactionString> transactionStrings)
    {   
        TransactionValidator transactionValidator = new TransactionValidator();

        foreach (TransactionString transactionString in transactionStrings)
        {
            if (transactionValidator.IsValidTransaction(transactionString))
            {
                var newTransaction = new Transaction(transactionString, AccountManager);
                ProcessTransaction(newTransaction);
            }
        }

    }

    public void ProcessTransaction(Transaction transaction){
        Transactions.Add(transaction);
        transaction.To.ReceiveMoney(transaction);
        transaction.From.SendMoney(transaction);
    }

    public void PrintAllTransactions()
    {
        Console.WriteLine("Printing all transactions:");
        foreach (Transaction transaction in Transactions)
        {
            transaction.PrintTransaction();
        }
    }

}