Console.WriteLine("============================================================================================");
// Exercise - Implement try-catch exception handling
// Implement a simple try-catch
double Float1 = 3000.0;
double Float2 = 0.0;
int Number1 = 3000;
int Number2 = 0;

try
{
    Console.WriteLine(Float1 / Float2);
    Console.WriteLine(Number1 / Number2);
}
catch
{
    Console.WriteLine("An exception has been caught");
}

Console.WriteLine("Exit program");

Console.WriteLine("============================================================================================");
// Catch exceptions thrown in called methods
try
{
    Process1();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

static void Process1()
{
    WriteMessage();
}

static void WriteMessage()
{
    double float1 = 3000.0;
    double float2 = 0.0;
    int number1 = 3000;
    int number2 = 0;

    Console.WriteLine(float1 / float2);
    Console.WriteLine(number1 / number2);
}

Console.WriteLine("============================================================================================");
// Exercise - Complete a challenge activity for try-catch
// Try-Catch challenge
try
{
    Process();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

static void Process()
{
    try
    {
        WriteMessage1();
    }
    catch
    {
        Console.WriteLine("Exception caught in Process");
    }
}

static void WriteMessage1()
{
    double float_1 = 3000.0;
    double float_2 = 0.0;
    int number_1 = 3000;
    int number_2 = 0;

    Console.WriteLine(float_1 / float_2);
    Console.WriteLine(number_1 / number_2);
}
Console.WriteLine("============================================================================================");
// Exercise - Catch specific exception types
