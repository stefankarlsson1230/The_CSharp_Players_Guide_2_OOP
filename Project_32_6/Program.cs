// Stopwatch – Time an operation with TimeSpan.

DateTime start, end;

Console.Write("Press any key to start");
Console.ReadKey(true);
start = DateTime.Now;


Console.Write("\nPress any key to stop");
Console.ReadKey(true);
end = DateTime.Now;

TimeSpan time = end - start;

Console.WriteLine($"\nElapsed time: {time.Seconds} second(s) and  {time.Milliseconds} millisecond(s)");


