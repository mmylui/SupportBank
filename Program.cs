using NLog;
using NLog.Config;
using NLog.Targets;

var config = new LoggingConfiguration();
var target = new FileTarget { FileName = @"/Users/mina/Documents/Software Development/TechSwitch/Training/SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
LogManager.Configuration = config;

Bank SupportBank = new Bank();

UserRequest userRequest = new UserRequest(SupportBank.UserRequestHandler);

userRequest.Run();