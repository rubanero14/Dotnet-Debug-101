/* 
This code uses a names array and corresponding methods to display
greeting messages
*/

/*
    ATTENTION!:
    - Once fixed is done, press stop debug process
    - Then in cli, type `dotnet clean' to delete the existing build files
    - Again in cli, `type dotnet build` to rebuild new build files based on the changes made (without these, the changes wont reflect and will keep showing previous code remnants)
    - You can start to debug now if you want by pressing Start Debugging in Run menu 
*/

string[] names = new string[] { "Sophia", "Andrew", "AllGreetings" };

string messageText = "";

foreach (string name in names)
{
    if (name == "Sophia")
        messageText = SophiaMessage();
    else if (name == "Andrew")
        messageText = AndrewMessage();
    else if (name == "AllGreetings")
        messageText = SophiaMessage() + "\n\r" + AndrewMessage();

    Console.WriteLine(messageText + "\n\r");
}

bool pauseCode = true;
while (pauseCode == true) ;

static string SophiaMessage()
{
    return "Hello, my name is Sophia.";
}

static string AndrewMessage()
{
    return "Hi, my name is Andrew. Good to meet you.";
}