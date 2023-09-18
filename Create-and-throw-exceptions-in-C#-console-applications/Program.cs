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

Console.WriteLine("============================================================================================");