using NLog;

class CSVReader
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public List<TransactionString> GetTransactionStrings(string fileName)
    {
        int lineNumber = 0;
        String? line;
        List<TransactionString> TransactionStrings = new List<TransactionString>();
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            // StreamReader sr = new StreamReader("./Transactions2014.csv");
            Logger.Info($"Reading from file: ${fileName}");
            StreamReader sr = new StreamReader(fileName);
            //Read the first line of text
            line = sr.ReadLine();
            line = sr.ReadLine();
            lineNumber = 2;
            //Continue to read until you reach end of file
            while (line != null)
            {
                var parseLine = new TransactionString(line);
                TransactionStrings.Add(parseLine);
                //Read the next line
                line = sr.ReadLine();
                lineNumber++;
            }
            //close the file
            sr.Close();
        }
        catch(Exception e)
        {
            if(lineNumber>0){
                Logger.Error($"Error reading from file: {fileName} lineNumber: £{lineNumber}");
            }else{
                Logger.Error($"Error reading from file: {fileName}");
            }
            Logger.Error($"Exception Message: {e.Message}");
            Console.WriteLine("Exception: " + e.Message);
        } 
        return TransactionStrings;
    }
}