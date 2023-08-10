using NLog;
using System.Globalization;
class TransactionValidator
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    public ValidationResponse ReturnValidationResponse(TransactionString transactionString, int lineNumber)
    {
        bool dateIsValid = DateIsValid(transactionString.Date);
        bool amountIsValid = AmountIsValid(transactionString.Amount);
        bool transactionValid = dateIsValid && amountIsValid;

        if (transactionValid)
        {
            return new ValidationResponse(true, "");
        }
        else
        {
            string errorMessage = $"Error processing line {lineNumber}:\n";
            if (!dateIsValid){
                errorMessage += $"\tDate: '{transactionString.Date}' is not a valid date.\n";
            }
            if (!amountIsValid){
                errorMessage += $"\tAmount: '{transactionString.Amount}' is not a valid amount.\n";
            }
            return new ValidationResponse(false, errorMessage);
        }
    }

    public bool IsValidTransaction(TransactionString transactionString){
        bool dateIsValid = DateIsValid(transactionString.Date);
        bool amountIsValid = AmountIsValid(transactionString.Amount);
        return dateIsValid && amountIsValid;
    }

    private bool DateIsValid(string datetimestring)
    {
        if (DateTime.TryParse(datetimestring, CultureInfo.GetCultureInfo("en-GB").DateTimeFormat, DateTimeStyles.None, out DateTime Date))
        {
            return true;
        }
        else
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
        }
        else
        {
            Logger.Error($"Error parsing string to decimal {amountString}");
            return false;
        }
    }
}