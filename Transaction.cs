using System.Globalization;
class Transaction
{
    public DateTime Date { get; set; }

    public string To { get; set; }
    public string From { get; set; }
    public string Narrative { get; set; }
    public decimal Amount { get; set; }
    
    public Transaction(TransactionString transactionString)
    {   
        Date = DateTime.Parse(transactionString.Date, CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);
        From = transactionString.From;
        To = transactionString.To;
        Narrative = transactionString.Narrative;
        Amount = decimal.Parse(transactionString.Amount);
    }

    public void PrintTransaction()
    {
        Console.WriteLine($"Date: {Date} From: {From} To: {To} Narrative: {Narrative} Amount: {Amount}");
    }
}