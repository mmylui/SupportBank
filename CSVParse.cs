class CSVParse
{
    public string Date;
    public string From;
    public string To;
    public string Narrative;
    public string Amount;
    public CSVParse (string line)
    {
        string[] subs = line.Split(',');
        string Date = subs[0];
        string From = subs[1];
        string To = subs[2];
        string Narrative = subs[3];
        string Amount = subs[4];
    }
}