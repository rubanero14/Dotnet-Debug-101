// Console.WriteLine("============================================================================================");
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

// Console.WriteLine("============================================================================================");

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

// Console.WriteLine("============================================================================================");
// More on Exceptions and Exception Handling - https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/

// Code samples for compiler-generated exceptions

// ArrayTypeMismatchException example
// string[] names = { "Dog", "Cat", "Fish" };
// Object[] objs = (Object[])names;
// Object obj = (Object)13;
// objs[2] = obj; // ArrayTypeMismatchException occurs


// DivideByZeroException example
// int number1 = 3000;
// int number2 = 0;
// Console.WriteLine(number1 / number2); // DivideByZeroException occurs


// FormatException example
// int valueEntered;
// string userValue = "two";
// valueEntered = int.Parse(userValue); // FormatException occurs


// IndexOutOfRangeException example
// int[] values1 = { 3, 6, 9, 12, 15, 18, 21 };
// int[] values2 = new int[6];
// values2[values1.Length - 1] = values1[values1.Length - 1]; // IndexOutOfRangeException occurs


// InvalidCastException example
// object obj = "This is a string";
// int num = (int)obj;


// NullReferenceException example
// attempting to access an element of a null array
// int[] values = null;
// for (int i = 0; i <= 9; i++)
//     values[i] = i * 2;

// attempting to access a method of a null string
// string? lowCaseString = null;
// Console.WriteLine(lowCaseString.ToUpper());


// OverflowException example
// decimal x = 400;
// byte i;
// i = (byte)x; // OverflowException occurs
// Console.WriteLine(i);

Console.WriteLine("============================================================================================");
