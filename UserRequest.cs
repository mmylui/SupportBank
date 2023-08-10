class UserRequest
{
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
            if(userCommand != null){
                switch(userCommand)
                {
                    case "List All":
                        UserRequestHandler.HandleListAll();
                        break;
                    case "List Account":
                        Console.Write("Enter Name: ");
                        string accountName = Console.ReadLine();
                        UserRequestHandler.HandleListAccount(accountName);
                        break;
                    case "Exit":
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