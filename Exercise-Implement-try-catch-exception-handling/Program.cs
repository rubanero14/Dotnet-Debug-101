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
try
{
    Process2();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

// static void Process2()
// {
//     try
//     {
//         WriteMessage2();
//     }
//     catch (Exception ex)
//     {
//         // Examine exception properties
//         Console.WriteLine("Exception caught in Process2");
//         Console.WriteLine($@"ex.Message: {ex.Message}");
//         Console.WriteLine($@"ex.Data: {ex.Data}");
//         Console.WriteLine($@"ex.HelpLink: {ex.HelpLink}");
//         Console.WriteLine($@"ex.HResult: {ex.HResult}");
//         Console.WriteLine($@"ex.InnerException: {ex.InnerException}");
//         Console.WriteLine($@"ex.Source: {ex.Source}");
//         Console.WriteLine($@"ex.StackTrace: {ex.StackTrace}");
//         Console.WriteLine($@"ex.TargetSite: {ex.TargetSite}");

//         Console.WriteLine("ex.Message: {0}", ex.Message); // Another way of logging
//     }
// }

// Catch a specific exception type
static void Process2()
{
    try
    {
        WriteMessage2();
    }
    catch (DivideByZeroException ex)
    {
        // Examine DivideByZeroException exception properties
        Console.WriteLine("Exception caught in Process2");
        Console.WriteLine($@"ex.Message: {ex.Message}");
        Console.WriteLine($@"ex.Data: {ex.Data}");
        Console.WriteLine($@"ex.HelpLink: {ex.HelpLink}");
        Console.WriteLine($@"ex.HResult: {ex.HResult}");
        Console.WriteLine($@"ex.InnerException: {ex.InnerException}");
        Console.WriteLine($@"ex.Source: {ex.Source}");
        Console.WriteLine($@"ex.StackTrace: {ex.StackTrace}");
        Console.WriteLine($@"ex.TargetSite: {ex.TargetSite}");

        Console.WriteLine("ex.Message: {0}", ex.Message); // Another way of logging
    }
}

// Catch multiple exceptions in a code block

// static void WriteMessage2()
// {
//     double Float_1 = 3000.0;
//     double Float_2 = 0.0;
//     int Number_1 = 3000;
//     int Number_2 = 0;

//     Console.WriteLine(Float_1 / Float_2);
//     Console.WriteLine(Number_1 / Number_2);
// }

// To test if the DivideByZeroException exception catches other types of exceptions
static void WriteMessage2()
{
    double Float_1 = 3000.0;
    double Float_2 = 0.0;
    int Number_1 = 3000;
    int Number_2 = 0;
    byte smallNumber;

    try
    {
        Console.WriteLine(Float_1 / Float_2);
        Console.WriteLine(Number_1 / Number_2);
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Exception caught in WriteMessage: {ex.Message}");
    }
    checked
    {
        smallNumber = (byte)Number_1;
    }
}
/*
    Notice the use of the checked statement in the code above:
    -When performing integral type calculations that assign the value of one integral type to another integral type, the result depends on the overflow-checking context. In a checked context, the conversion succeeds if the source value is within the range of the destination type. Otherwise, an OverflowException is thrown. In an unchecked context, the conversion always succeeds, and proceeds as follows:
    -If the source type is larger than the destination type, then the source value is truncated by discarding its "extra" most significant bits. The result is then treated as a value of the destination type.
    -If the source type is smaller than the destination type, then the source value is either sign-extended or zero-extended so that it's of the same size as the destination type. Sign-extension is used if the source type is signed; zero-extension is used if the source type is unsigned. The result is then treated as a value of the destination type.
    -If the source type is the same size as the destination type, then the source value is treated as a value of the destination type.
*/
Console.WriteLine("============================================================================================");
// Catch separate exception types in a code block
// inputValues is used to store numeric values entered by a user
string[] inputValues = new string[] { "three", "9999999999", "0", "2" };

foreach (string inputValue in inputValues)
{
    int numValue = 0;
    try
    {
        numValue = int.Parse(inputValue);
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid readResult. Please enter a valid number.");
    }
    catch (OverflowException)
    {
        Console.WriteLine("The number you entered is too large or too small.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
Console.WriteLine("============================================================================================");
