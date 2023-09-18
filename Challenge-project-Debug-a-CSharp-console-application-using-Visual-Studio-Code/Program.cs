﻿/*
This application manages transactions at a store check-out line. The
check-out line has a cash register, and the register has a cash till
that is prepared with a number of bills each morning. The till includes
bills of four denominations: $1, $5, $10, and $20. The till is used
to provide the customer with change during the transaction. The item 
cost is a randomly generated number between 2 and 49. The customer 
offers payment based on an algorithm that determines a number of bills
in each denomination. 

Each day, the cash till is loaded at the start of the day. As transactions
occur, the cash till is managed in a method named MakeChange (customer 
payments go in and the change returned to the customer comes out). A 
separate "safety check" calculation that's used to verify the amount of
money in the till is performed in the "main program". This safety check
is used to ensure that logic in the MakeChange method is working as 
expected.
*/
/*
    Objective:
    - Simulate transactions: the top-level statements configure application data and simulate a series of transactions using either a small testData array or a 
      larger number of randomly generated transactions.
    - Initialize the till: the LoadTillEachMorning method is used to configure the cash register till with a predefined number of bills in each denomination.
    - Process transactions: the MakeChange method is used to manage the cash till during purchase transactions.
    - Report till status: the LogTillStatus method is used to display the number of bills of each denomination currently in the till.
    - Report till balance: the TillAmountSummary method is used display a message showing the amount of cash in the till.
*/
string? readResult = null;
bool useTestData = true;

Console.Clear();

int[] cashTill = new int[] { 0, 0, 0, 0 };
int registerCheckTillTotal = 0;

// registerDailyStartingCash: $1 x 50, $5 x 20, $10 x 10, $20 x 5 => ($350 total)
int[,] registerDailyStartingCash = new int[,] { { 1, 50 }, { 5, 20 }, { 10, 10 }, { 20, 5 } };

int[] testData = new int[] { 6, 10, 17, 20, 31, 36, 40, 41 };
int testCounter = 0;

LoadTillEachMorning(registerDailyStartingCash, cashTill);

for (int i = 0; i < registerDailyStartingCash.GetLength(0); i++)
{
    registerCheckTillTotal += (registerDailyStartingCash[i, 0] * registerDailyStartingCash[i, 1]);
}

// display the number of bills of each denomination currently in the till
LogTillStatus(cashTill);

// display a message showing the amount of cash in the till
Console.WriteLine(TillAmountSummary(cashTill));

// display the expected registerDailyStartingCash total
Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");

var valueGenerator = new Random((int)DateTime.Now.Ticks);

int transactions = 100;

if (useTestData)
{
    transactions = testData.Length;
}

while (transactions > 0)
{
    transactions -= 1;
    int itemCost = valueGenerator.Next(2, 49);

    if (useTestData)
    {
        itemCost = testData[testCounter];
        testCounter += 1;
    }

    int paymentOnes = itemCost % 2;                 // value is 1 when itemCost is odd, value is 0 when itemCost is even
    int paymentFives = (itemCost % 10 > 7) ? 1 : 0; // value is 1 when itemCost ends with 8 or 9, otherwise value is 0
    int paymentTens = (itemCost % 20 > 13) ? 1 : 0; // value is 1 when 13 < itemCost < 20 OR 33 < itemCost < 40, otherwise value is 0
    int paymentTwenties = (itemCost < 20) ? 1 : 2;  // value is 1 when itemCost < 20, otherwise value is 2

    // display messages describing the current transaction
    Console.WriteLine($"Customer is making a ${itemCost} purchase");
    Console.WriteLine($"\t Using {paymentTwenties} twenty dollar bills");
    Console.WriteLine($"\t Using {paymentTens} ten dollar bills");
    Console.WriteLine($"\t Using {paymentFives} five dollar bills");
    Console.WriteLine($"\t Using {paymentOnes} one dollar bills");

    try
    {
        // MakeChange manages the transaction and updates the till 
        MakeChange(itemCost, cashTill, paymentTwenties, paymentTens, paymentFives, paymentOnes);

        Console.WriteLine($"Transaction successfully completed.");
        registerCheckTillTotal += itemCost;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Could not complete transaction: {ex.Message}");
    }

    Console.WriteLine(TillAmountSummary(cashTill));
    Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");
    Console.WriteLine();
}

Console.WriteLine("Press the Enter key to exit");
do
{
    readResult = Console.ReadLine();

} while (readResult == null);


static void LoadTillEachMorning(int[,] registerDailyStartingCash, int[] cashTill)
{
    for (int i = 0; i < cashTill.GetLength(0); i++)
    {
        cashTill[i] = registerDailyStartingCash[i, 1];
    }
}


static void MakeChange(int cost, int[] cashTill, int twenties, int tens = 0, int fives = 0, int ones = 0)
{
    cashTill[3] += twenties;
    cashTill[2] += tens;
    cashTill[1] += fives;
    cashTill[0] += ones;

    int amountPaid = twenties * 20 + tens * 10 + fives * 5 + ones;
    int changeNeeded = amountPaid - cost;

    if (changeNeeded < 0)
        throw new InvalidOperationException("InvalidOperationException: Not enough money provided to complete the transaction.");

    Console.WriteLine("Cashier Returns:");

    while ((changeNeeded > 19) && (cashTill[3] > 0))
    {
        cashTill[3]--;
        changeNeeded -= 20;
        Console.WriteLine("\t A twenty");
    }

    while ((changeNeeded > 9) && (cashTill[2] > 0))
    {
        cashTill[2]--;
        changeNeeded -= 10;
        Console.WriteLine("\t A ten");
    }

    while ((changeNeeded > 4) && (cashTill[1] > 0))
    {
        cashTill[1]--;
        changeNeeded -= 5;
        Console.WriteLine("\t A five");
    }

    while ((changeNeeded > 0) && (cashTill[0] > 0))
    {
        cashTill[0]--;
        changeNeeded--;
        Console.WriteLine("\t A one");
    }

    if (changeNeeded > 0)
        throw new InvalidOperationException("InvalidOperationException: The till is unable to make the correct change.");

}

static void LogTillStatus(int[] cashTill)
{
    Console.WriteLine("The till currently has:");
    Console.WriteLine($"{cashTill[3] * 20} in twenties");
    Console.WriteLine($"{cashTill[2] * 10} in tens");
    Console.WriteLine($"{cashTill[1] * 5} in fives");
    Console.WriteLine($"{cashTill[0]} in ones");
    Console.WriteLine();
}

static string TillAmountSummary(int[] cashTill)
{
    return $"The till has {cashTill[3] * 20 + cashTill[2] * 10 + cashTill[1] * 5 + cashTill[0]} dollars";

}
