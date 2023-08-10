using Newtonsoft.Json;
using NLog;
class JSONReader{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public List<TransactionString> GetTransactionStrings(string fileName){

        string json;
        using (StreamReader r = new StreamReader(fileName))
        {
            json = r.ReadToEnd();
        }


        int lineNumber = 0;
        String? line;
        List<TransactionString> TransactionStrings = new List<TransactionString>();
        try
        {
            List<TransactionJSON>  transactionJSONs = JsonConvert.DeserializeObject<List<TransactionJSON>>(json); 
            Console.WriteLine(transactionJSONs.Count);    

            foreach(TransactionJSON transactionJSON in transactionJSONs){
                TransactionStrings.Add(new TransactionString(transactionJSON));
            }

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