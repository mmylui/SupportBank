using NLog;
class UserRequest
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    private UserRequestHandler UserRequestHandler;
    public UserRequest(UserRequestHandler userRequestHandler)
    {
        UserRequestHandler = userRequestHandler;
    }

    public void Run ()
    {
        var running = true;
        while (running)
        {
            Console.WriteLine("Enter command:\n'List All' - Show All Account Balances.\n'List Account' - Lets you specify a user to view\n'Exit'");
            string userCommand = Console.ReadLine();
            Logger.Info($"User command: {userCommand}");

            if(userCommand != null){
                switch(userCommand)
                {
                    case "List All":
                        Logger.Debug($"User command triggered 'List All' case");
                        UserRequestHandler.HandleListAll();
                        break;
                    case "List Account":
                        Logger.Debug($"User command triggered 'List Account' case");
                        Console.Write("Enter Name: ");
                        string accountName = Console.ReadLine();
                        Logger.Info($"User command: {userCommand} for name: {accountName}");
                        UserRequestHandler.HandleListAccount(accountName);
                        break;
                    case "Exit":
                        Logger.Debug($"User command triggered 'Exit' case");
                    
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Command invalid - please retry");
                        break;
                }
            }
        }
    }
}