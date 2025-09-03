Robot robot = new Robot();
int commands = 0;
string? input;

Console.WriteLine("Enter 3 commands (on, off, north, south, west, east)");
do
{
    Console.Write($"Command {commands}: ");
    input = Console.ReadLine();

    switch (input)
    {
        case "on":
            robot.Commands[commands] = new OnCommand();
            commands++;
            break;
        case "off":
            robot.Commands[commands] = new OffCommand();
            commands++;
            break;
        case "north":
            robot.Commands[commands] = new NorthCommand();
            commands++;
            break;
        case "south":
            robot.Commands[commands] = new SouthCommand();
            commands++;
            break;
        case "east":
            robot.Commands[commands] = new EastCommand();
            commands++;
            break;
        case "west":
            robot.Commands[commands] = new WestCommand();
            commands++;
            break;
        default:
            Console.WriteLine($"{input} is not a valid command!");
            break;
    }
}
while (commands < 3);


robot.Run();



// Classes
public class Robot
{
    // Properties
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

    // Methods
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}


public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}


public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}

