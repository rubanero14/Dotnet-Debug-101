using System;
/* 
This code uses a names array and corresponding methods to display
greeting messages
*/

/*
    ATTENTION!:
    - Once fixed is done, press stop debug process
    - Then in cli, type `dotnet clean' to delete the existing build files
    - Again in cli, `type dotnet build` to rebuild new build files based on the changes made (without these, the changes wont reflect and will keep showing previous code remnants)
    - You can start to debug now if you want by pressing Start ebugging in Run menu 
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

static string SophiaMessage()
{
    return "Hello, my name is Sophia.";
}

static string AndrewMessage()
{
    return "Hi, my name is Andrew. Good to meet you.";
}

Console.WriteLine("============================================================================================");

// Configure conditional breakpoints in C#
// Configure a conditional breakpoint using an expression
int productCount = 2000;
string[,] products = new string[productCount, 2];

LoadProducts(products, productCount);

for (int i = 0; i < productCount; i++)
{
    string result;
    result = Process1(products, i); // added conditional breakpoint using a boolean expression => products[i,1] == "new";

    if (result != "obsolete")
    {
        result = Process2(products, i);
    }
}

bool pauseCode = true;
while (pauseCode == true) ;

static void LoadProducts(string[,] products, int productCount)
{
    Random rand = new Random();

    for (int i = 0; i < productCount; i++)
    {
        int num1 = rand.Next(1, 10000) + 10000;
        int num2 = rand.Next(1, 101);

        string prodID = num1.ToString();

        if (num2 < 91)
        {
            products[i, 1] = "existing";
        }
        else if (num2 == 91)
        {
            products[i, 1] = "new";
            prodID = prodID + "-n";
        }
        else
        {
            products[i, 1] = "obsolete";
            prodID = prodID + "-0";
        }

        products[i, 0] = prodID;
    }
}

static string Process1(string[,] products, int item)
{
    Console.WriteLine($"Process1 message - working on {products[item, 1]} product");

    return products[item, 1];
}

static string Process2(string[,] products, int item)
{
    Console.WriteLine($"Process2 message - working on product ID #: {products[item, 0]}");
    if (products[item, 1] == "new")
        Process3(products, item);

    return "continue";
}

static void Process3(string[,] products, int item)
{
    Console.WriteLine($"Process3 message - processing product information for 'new' product");
}

Console.WriteLine("============================================================================================");

// Exercise - Monitor variables and execution flow
// Configure your application and launch configuration
/*
    NOTE:
    When you're working on a console application that reads user input, you'll probably need to update launch configuration file.
*/

string? readResult;
int startIndex = 0;
bool goodEntry = false;

int[] numbers = { 1, 2, 3, 4, 5 };

// Display the array to the console.
Console.Clear();
Console.Write("\n\rThe 'numbers' array contains: { ");
foreach (int number in numbers)
{
    Console.Write($"{number} ");
}

// To calculate a sum of array elements, 
// prompt the user for the starting element number.
Console.WriteLine($"}}\n\r\n\rTo sum values 'n' through 5, enter a value for 'n':");
while (goodEntry == false)
{
    readResult = Console.ReadLine();
    goodEntry = int.TryParse(readResult, out startIndex);

    if (startIndex > 5)
    {
        goodEntry = false;
        Console.WriteLine("\n\rEnter an integer value between 1 and 5");
    }
}

// Display the sum and then pause.
Console.WriteLine($"\n\rThe sum of numbers {startIndex} through {numbers.Length} is: {SumValues(numbers, startIndex)}");

Console.WriteLine("press Enter to exit");
readResult = Console.ReadLine();

// My SOLUTION
// This method returns the sum of elements n through 5
static int SumValues(int[] numbers, int n = 0)
{
    int sum = n;
    for (int i = n; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }
    return sum;
}

Console.WriteLine("============================================================================================");

// // Monitor watch expressions
bool exit = false;
var rand = new Random();
int num1 = 5;
int num2 = 5;

do
{
    num1 = rand.Next(1, 11);
    num2 = num1 + rand.Next(1, 51);

} while (exit == false);

Console.WriteLine("============================================================================================");

// Exercise - Complete a challenge activity using the debugger
// Variable state challenge
/*  
This code instantiates a value and then calls the ChangeValue method
to update the value. The code then prints the updated value to the console.
*/
int x = 5;

ChangeValue(10);

Console.WriteLine(x);

void ChangeValue(int value)
{
    x = value;
}

Console.WriteLine("============================================================================================");
/*
    Reference materials: 
        - You can find additional information about the Visual Studio Code debugger here: https://code.visualstudio.com/docs/editor/debugging.

        - You can find additional information about the OmniSharp debugger for C# here: https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger.md.

        - You can find additional information about the OmniSharp debugger and the launch.json file here: https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger-launchjson.md.

        - You can find additional information about advanced launch configuration scenarios here: https://code.visualstudio.com/docs/editor/debugging.

*/