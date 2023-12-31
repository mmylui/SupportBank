class TransactionString
{
    public string Date;
    public string From;
    public string To;
    public string Narrative;
    public string Amount;
    public TransactionString (string line)
    {
        string[] subs = line.Split(',');
        Date = subs[0];
        From = subs[1];
        To = subs[2];
        Narrative = subs[3];
        Amount = subs[4];
    }

    public TransactionString(TransactionJSON transactionJSON){
        Date = transactionJSON.Date;
        From = transactionJSON.FromAccount;
        To = transactionJSON.ToAccount;
        Narrative = transactionJSON.Narrative;
        Amount = transactionJSON.Amount;
    }


}