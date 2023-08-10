using System.Globalization;
using NLog;

class Transaction
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    public DateTime Date { get; set; }

    public Account To { get; set; }
    public Account From { get; set; }
    public string Narrative { get; set; }
    public decimal Amount { get; set; }
    
    public Transaction(TransactionString transactionString, AccountManager accountManager)
    {   
        Date = DateTime.Parse(transactionString.Date, CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);
        From = accountManager.GetAccountForTransaction( transactionString.From);
        To = accountManager.GetAccountForTransaction(transactionString.To);
        Narrative = transactionString.Narrative;
        Amount = decimal.Parse(transactionString.Amount);
        // Logger.Info($"Transaction registered on {Date}, from {From}, to {To}, for {Narrative}, amount {Amount}");
    }

    public void PrintTransaction()
    {
        Console.WriteLine("===========================");
        Console.WriteLine($"Date: {Date.Day}/{Date.Month}/{Date.Year}");
        Console.WriteLine($"\tFrom: {From.Name} To: {To.Name}");
        Console.WriteLine($"\tFor: {Narrative}");
        Console.WriteLine($"\tAmount: £{Amount}");
    }
}