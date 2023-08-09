class CSVReader
{
    public void PrintFile()
    {
        String line;
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("./Transactions2014.csv");
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                // Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
                var parseLine = new CSVParse(line);
                var newTransaction = new Transaction(parseLine.Date, parseLine.From, parseLine.To, parseLine.Narrative, parseLine.Amount);
                newTransaction.PrintTransaction();
            }
            //close the file
            sr.Close();
            Console.ReadLine();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }  
    }
}