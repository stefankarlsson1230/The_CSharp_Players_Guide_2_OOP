// Split Name - Return (first, last) from full name.

string input;
(string First, string Last) fullName;

Console.Write("Enter your full name: ");
input = Console.ReadLine();
fullName = SplitName(input);

Console.WriteLine($"Firstname: {fullName.First}");
Console.WriteLine($"Lastname: {fullName.Last}");


// Local Functions

(string first, string last) SplitName(string name)
{
    string[] firstAndLast = name.Split(' ');

    return (firstAndLast[0], firstAndLast[1]);
}

