using NLog;
using System.Globalization;
class TransactionValidator
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    public bool IsValidTransaction(TransactionString transactionString)
    {
        bool dateIsValid = DateIsValid(transactionString.Date);
        bool amountIsValid = AmountIsValid(transactionString.Amount);
        return dateIsValid && amountIsValid;
    }

    private bool DateIsValid(string datetimestring)
    {   
        if (DateTime.TryParse(datetimestring, CultureInfo.GetCultureInfo("en-GB").DateTimeFormat, DateTimeStyles.None, out DateTime Date))
        {
            return true;
        } else
        {
            Logger.Error($"Error parsing string to dateTime {datetimestring}");
            return false;
        }
    }
    private bool AmountIsValid(string amountString)
    {   
        if (decimal.TryParse(amountString, out decimal Amount))
        {
            return true;
        } else
        {
            Logger.Error($"Error parsing string to decimal {amountString}");
            return false;
        }
    }
}