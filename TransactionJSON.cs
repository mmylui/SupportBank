class TransactionJSON{
    private string _date;
    public string Date {get{
        return _date;
    } set{
        _date = value.ToString();
    }}
    public string FromAccount{get; set;}
    public string ToAccount {get; set;}
    public string Narrative {get; set;}
    private string _amount;
    public string Amount {get{
        return _amount;
    } set{
        _amount = value.ToString();
    }}
}