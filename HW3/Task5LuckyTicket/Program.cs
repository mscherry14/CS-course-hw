// See https://aka.ms/new-console-template for more information

using Task5LuckyTicket;

string? input = null;
while (input is null)
{
    Console.WriteLine("Please enter a number of digits for lucky tickets' counting:");
    input = Console.ReadLine();
}

if (int.TryParse(input, out var x))
{
    try
    {
        Int128 res = LuckyTicket.Count(x);
        Console.WriteLine(res);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e);
    }
}
else
{
    Console.WriteLine("Invalid input: int parsing failed. Restart the program to try again.");
}