Bank SupportBank = new Bank();

var userRequestHandler = SupportBank.UserRequestHandler;

Console.WriteLine("Enter command:\n'List All' - Show All Account Balances.\n'List Account' - Lets you specify a user to view");
string userCommand = Console.ReadLine();
if(userCommand != null){
    userRequestHandler.HandleRequest(userCommand);
}


