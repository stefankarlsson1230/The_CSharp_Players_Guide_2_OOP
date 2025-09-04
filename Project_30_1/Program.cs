
ColoredItem<Sword> sword = new(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> bow = new(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> axe = new(new Axe(), ConsoleColor.DarkGreen);

sword.Display();
bow.Display();
axe.Display();



// Classes
public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T> where T : class
{
    public T Item { get; }
    public ConsoleColor Color { get; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(this);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}