// Use DateTime to count days.

int startYear, startMonth, startDate, endYear, endMonth, endDate;

Console.Write("Start year: ");
startYear = int.Parse(Console.ReadLine());
Console.Write("Start month: ");
startMonth = int.Parse(Console.ReadLine());
Console.Write("Start date: ");
startDate = int.Parse(Console.ReadLine());

Console.Write("End year: ");
endYear = int.Parse(Console.ReadLine());
Console.Write("End month: ");
endMonth = int.Parse(Console.ReadLine());
Console.Write("End day: ");
endDate = int.Parse(Console.ReadLine());

DateTime start = new DateTime(startYear, startMonth, startDate);
DateTime end = new DateTime(endYear, endMonth, endDate);

TimeSpan difference = end - start;

Console.WriteLine($"There are {difference.TotalDays} days between {start.ToShortDateString()} and {end.ToShortDateString()}");

