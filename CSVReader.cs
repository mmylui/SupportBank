class CSVReader
{
    public List<TransactionString> GetTransactionStrings()
    {
        String? line;
        List<TransactionString> TransactionStrings = new List<TransactionString>();
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("./Transactions2014.csv");
            //Read the first line of text
            line = sr.ReadLine();
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                // Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
                var parseLine = new TransactionString(line);
                TransactionStrings.Add(parseLine);
            }
            //close the file
            sr.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block."); 
        }  
        return TransactionStrings;
    }
}