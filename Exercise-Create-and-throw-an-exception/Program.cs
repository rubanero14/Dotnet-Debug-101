Console.WriteLine("============================================================================================");
// Exercise - Create and throw an exception
// ThrowExceptions101
// Prompt the user for the lower and upper bounds
// My Own Solution
int lowerBound = 0;
int upperBound = 0;
decimal averageValue = 0;
bool exit = false;

do
{
    try
    {
        Console.Write("Enter the lower bound: ");
        lowerBound = int.Parse(Console.ReadLine());

        Console.Write("Enter the upper bound: ");
        upperBound = int.Parse(Console.ReadLine());

        // Calculate the sum of the even numbers between the bounds
        averageValue = AverageOfEvenNumbers(lowerBound, upperBound);

        // Display the value returned by AverageOfEvenNumbers in the console
        Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");

        // Wait for user input
        Console.ReadLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error has occurred.");
        Console.WriteLine(ex.Message);
        if (ex is FormatException && ex.StackTrace.Contains("line 12"))
        {
            Console.WriteLine("Please enter integer value for Lower bound!");
            // throw new InvalidCastException();
        }
        else if (ex is FormatException && ex.StackTrace.Contains("line 15"))
        {
            Console.WriteLine("Please enter integer value for Upper bound!");
            // throw new InvalidCastException($"Please enter integer value for Upper bound!");
        }
        else if (ex is DivideByZeroException)
        {
            Console.WriteLine($"The upper bound must be greater than {lowerBound}");
            // throw new DivideByZeroException("Please enter Upper bound number higher than Lower bound number!");
        }

        Console.WriteLine("Try again? or type \"exit\" to exit the program...");
        string? exitPermission = Console.ReadLine();

        exit = exitPermission.ToLower() == "exit" ? true : false;
    }
} while (exit == false);


static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
{
    int sum = 0;
    int count = 0;
    decimal average = 0;

    for (int i = lowerBound; i <= upperBound; i++)
    {
        if (i % 2 == 0)
        {
            sum += i;
            count++;
        }
    }

    average = (decimal)sum / count;

    return average;
}
Console.WriteLine("============================================================================================");
