class Transaction
{
    private string _date;
    public string Date
    {
        get; set;
        // get { return _date; }
        // set { _date = DateTime.Parse(value); }
    }

    public string To { get; set; }
    public string From { get; set; }
    public string Narrative { get; set; }

    private string _amount;
    public string Amount
    { get; set; }
        // get { return _amount; }
        // set { _amount = decimal.Parse(value); }
    // }
    
    public Transaction(string date, string from, string to, string narrative, string amount)
    {
        Date = date;
        From = from;
        To = to;
        Narrative = narrative;
        Amount = amount;
    }

    public void PrintTransaction()
    {
        Console.WriteLine(From);
        // Console.WriteLine($"Date: {Date} From: {From} To: {To} Narrative: {Narrative} Amount: {Amount}");
    }
}