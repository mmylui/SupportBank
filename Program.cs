using NLog;
using NLog.Config;
using NLog.Targets;



var config = new LoggingConfiguration();
var target = new FileTarget { FileName = Variables.loggingPath, Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, target));
LogManager.Configuration = config;

Bank SupportBank = new Bank();

// bool bankStartedSuccessfully = SupportBank.SetupBank("./DodgyTransactions2015.csv");
bool bankStartedSuccessfully = SupportBank.SetupBank("./Transactions2013.json");

if(bankStartedSuccessfully){
    UserRequest userRequest = new UserRequest(SupportBank.UserRequestHandler);
    userRequest.Run();
}

Console.WriteLine("Program Exiting...\n\n");
