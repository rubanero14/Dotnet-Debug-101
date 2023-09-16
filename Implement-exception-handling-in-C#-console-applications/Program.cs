Console.WriteLine("============================================================================================");
// Implement exception handling in C# console applications

// Examine exceptions and the exception handling process
// Exception handling keywords, code blocks, and patterns
try
{
    // try code block - code that may generate an exception
}
catch
{
    // catch code block - code to handle an exception
}
finally
{
    // finally code block - code to clean up resources
}

Console.WriteLine("============================================================================================");

// Exception handling process
try
{
    // Step 1: code execution begins
    try
    {
        // Step 2: an exception occurs here
    }
    finally
    {
        // Step 4: the system executes the finally code block associated with the try statement where the exception occurred
    }

}
catch // Step 3: the system finds a catch clause that can handle the exception
{
    // Step 5: the system transfers control to the first line of the catch code block
}

/*
    In this example as above, the following process occurs:

    Execution begins in the code block of the outer try statement.
    An exception is thrown in the code block of the inner try statement.
    The runtime finds the catch clause associated with the outer try statement.
    Before the runtime transfers control to the first line of the catch code block, it executes the finally clause associated with the inner try statement.
    The runtime then transfers control to the first line of the catch code block and executes the code that handles the exception.
*/

Console.WriteLine("============================================================================================");

// More on Exceptions and Exception Handling - https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/