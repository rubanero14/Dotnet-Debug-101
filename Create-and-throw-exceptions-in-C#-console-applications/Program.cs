Console.WriteLine("============================================================================================");
// Examine how to create and throw exceptions in C#
// Create an exception object
/*
    Here are some common exception types that you might use when creating an exception:
    - ArgumentException or ArgumentNullException: Use these exception types when a method or constructor is called with an invalid argument value or null reference.
    - InvalidOperationException: Use this exception type when the operating conditions of a method don't support the successful completion of a particular method call.
    - NotSupportedException: Use this exception type when an operation or feature is not supported.
    - IOException: Use this exception type when an input/output operation fails.
    - FormatException: Use this exception type when the format of a string or data is incorrect.
*/

// The new keyword is used to create an instance of an exception. For example, you can create an instance of the ArgumentException exception type as follows:
ArgumentException invalidArgumentException = new ArgumentException();
Console.WriteLine("============================================================================================");
// Configure and throw customized exceptions
// For example, the following code creates an exception object named invalidArgumentException with a custom Message property, and then throws the exception:
ArgumentException invalidArgumentException = new ArgumentException("ArgumentException: The 'GraphData' method received data outside the expected range.");
throw invalidArgumentException;

// An exception object can also be created directly within a throw statement. For example:
throw new FormatException("FormatException: Calculations in process XYZ have been cancelled due to invalid data format.");
Console.WriteLine("============================================================================================");
// When to throw an exception
// The exception object can be configured with application specific information in the property values. The following code sample demonstrates the scenario:
string[][] userEnteredValues = new string[][]
{
        new string[] { "1", "two", "3"},
        new string[] { "0", "1", "2"}
};

foreach (string[] userEntries in userEnteredValues)
{
    try
    {
        BusinessProcess1(userEntries);
    }
    catch (Exception ex)
    {
        if (ex.StackTrace.Contains("BusinessProcess1") && (ex is FormatException))
        {
            Console.WriteLine(ex.Message);
        }

        // re-throw the original exception object for further handling down the call stack
        // throw;
        /*
            When you re-throw an exception, the original exception object is used, so you don't lose any information about the exception. 
            If you want to create a new exception object that wraps the original exception, 
            you can pass the original exception as an argument to the constructor of a new exception object. For example:
        */
        // create a new exception object that wraps the original exception
        throw new ApplicationException("An error occurred", ex);
    }
}

static void BusinessProcess1(String[] userEntries)
{
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        try
        {
            valueEntered = int.Parse(userValue);

            // completes required calculations based on userValue
            // ...
        }
        catch (FormatException)
        {
            FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
            throw invalidFormatException;
        }
    }
}
Console.WriteLine("============================================================================================");
/*
    For the "BusinessProcess1" application scenario, consider the following updates:
    - The BusinessProcess1 method has been updated to include additional details. BusinessProcess1 now encounters two issues and must generate exceptions for each issue.
    - The top-level statements have been updated. Top-level statements now call the OperatingProcedure1 method. OperatingProcedure1 calls BusinessProcess1 within a try code block.
    - The OperatingProcedure1 method is able to handle one of the exception types and partially handle the other. Once the partially handled exception is processed, OperatingProcedure1 must re-throw the original exception.
*/
try
{
    OperatingProcedure1();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("Exiting application.");
}

static void OperatingProcedure1()
{
    string[][] userEnteredValues = new string[][]
    {
        new string[] { "1", "two", "3"},
        new string[] { "0", "1", "2"}
    };

    foreach (string[] userEntries in userEnteredValues)
    {
        try
        {
            BusinessProcess1(userEntries);
        }
        catch (Exception ex)
        {
            if (ex.StackTrace.Contains("BusinessProcess1"))
            {
                if (ex is FormatException)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Corrective action taken in OperatingProcedure1");
                }
                else if (ex is DivideByZeroException)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Partial correction in OperatingProcedure1 - further action required");

                    // re-throw the original exception
                    throw;
                }
                else
                {
                    // create a new exception object that wraps the original exception
                    throw new ApplicationException("An error occurred - ", ex);
                }
            }
        }

    }
}

static void BusinessProcess1(String[] userEntries)
{
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        try
        {
            valueEntered = int.Parse(userValue);

            checked
            {
                int calculatedValue = 4 / valueEntered;
            }
        }
        catch (FormatException)
        {
            FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
            throw invalidFormatException;
        }
        catch (DivideByZeroException)
        {
            DivideByZeroException unexpectedDivideByZeroException = new DivideByZeroException("DivideByZeroException: Calculation in 'BusinessProcess1' encountered an unexpected divide by zero");
            throw unexpectedDivideByZeroException;

        }
    }
}
Console.WriteLine("============================================================================================");

