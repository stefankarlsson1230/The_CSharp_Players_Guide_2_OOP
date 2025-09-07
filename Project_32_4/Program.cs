// Dice Roller - Use Random class.

using System.Text;

Console.Write("Enter dice to roll (eg. 2D6/5D12/1d8): ");
string input = Console.ReadLine().ToLower();

string[] inputSplit = input.Split('d');
int noOfDice = int.Parse(inputSplit[0]);
int typeOfDice = int.Parse(inputSplit[1]);

int result = 0;
StringBuilder resultString = new StringBuilder("Result: ");
Random random = new();
int dieRoll;

for (int i = 1; i <= noOfDice; i++)
{
    dieRoll = random.Next(typeOfDice) + 1;
    resultString.Append(dieRoll);
    if (i != noOfDice) resultString.Append(" + ");
    result += dieRoll;
}

resultString.Append($" = {result}");

Console.WriteLine(resultString.ToString());

