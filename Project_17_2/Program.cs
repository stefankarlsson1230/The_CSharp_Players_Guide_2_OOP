// Return Stats - Return min, max, average from method.

int[] numbers = [2, 13, 45, 99, 56, 12, 67, 4];

(int Min, int Max, double Average) values;


Console.Write("Values:");
foreach(int number in numbers)
{
    Console.Write(" {0} ", number);
}
Console.WriteLine();

values = GetValues(numbers);

Console.WriteLine("Min: " + values.Min);
Console.WriteLine("Max: " + values.Max);
Console.WriteLine($"Average: {values.Average:0.00}");



// Local functions
(int, int, double) GetValues(int[] numbers)
{
    int min = int.MaxValue;
    int max = int.MinValue;
    double average = 0;

    foreach (int n in numbers)
    {
        if (n < min)
        {
            min = n;
        }

        if (n > max)
        {
            max = n;
        }

        average += n;
    }

    average /= numbers.Length;

    return(min, max, average);
}
