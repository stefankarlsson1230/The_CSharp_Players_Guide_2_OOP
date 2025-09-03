
FirstLogger log1 = new();
SecondLogger log2 = new();
ThirdLogger log3 = new();

log1.Log();
log2.Log();
log3.Log();

Console.WriteLine();

PassingThrough person = new();

person.SayHello();
person.SayGoodbye();


// ILogger – Multiple classes implement Log() differently.
interface ILogger
{
    void Log();
}

public class FirstLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("This is from the First Logger!");
    }
}

public class SecondLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("This is from the Second Logger!");
    }
}

public class ThirdLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("This is from the Third Logger!");
    }
}



// Composite Interface – Implement multiple interfaces in one object.
interface FirstInterface
{
    void SayHello();
}

interface SecondInterface
{
    void SayGoodbye();
}


public class PassingThrough : FirstInterface, SecondInterface
{
    public void SayHello()
    {
        Console.WriteLine("Hello!");
    }

    public void SayGoodbye()
    {
        Console.WriteLine("Goodbye!");
    }
}

