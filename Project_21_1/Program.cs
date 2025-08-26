Arrow arrow;
int input = -1;

while (input < 1 || input > 2)
{
    Console.Write("Do you want 1. a standard arrow or 2. a custom made arrow? ");
    input = int.Parse(Console.ReadLine());
}

if (input == 1)
{
    input = -1;

    while (input < 1 || input > 3)
    {
        Console.Write("Choose arrowtype (1. Elite Arrow, 2. Beginner Arrow, 3. Marksman Arrow): ");
        input = int.Parse(Console.ReadLine());
    }

    arrow = input switch
    {
        1 => Arrow.CreateEliteArrow(),
        2 => Arrow.CreateBeginnerArrow(),
        3 => Arrow.CreateMarksmanArrow(),
    };
}
else
{

    arrow = new Arrow();
    input = -1;

    while (input < 1 || input > 3)
    {
        Console.Write("Choose arrowhead (1. Steel, 2. Wood, 3. Obsidian): ");
        input = int.Parse(Console.ReadLine());
    }

    switch (input)
    {
        case 1:
            arrow.Arrowhead = Arrowhead.Steel;
            break;
        case 2:
            arrow.Arrowhead = Arrowhead.Wood;
            break;
        case 3:
            arrow.Arrowhead = Arrowhead.Obsidian;
            break;
    }

    input = -1;

    while (input < 1 || input > 3)
    {
        Console.Write("Choose fletching (1. Plastic, 2. Turkey, 3. Goose): ");
        input = int.Parse(Console.ReadLine());
    }

    switch (input)
    {
        case 1:
            arrow.Fletching = Fletching.Plastic;
            break;
        case 2:
            arrow.Fletching = Fletching.Turkey;
            break;
        case 3:
            arrow.Fletching = Fletching.Goose;
            break;
    }


    while (input < 60 || input > 100)
    {
        Console.Write("Choose shaft-legth (60 - 100 cm): ");
        input = int.Parse(Console.ReadLine());
    }

    arrow.Shaft = input;
}

Console.WriteLine($"Your {arrow.Shaft} cm long arrow, with a {arrow.Arrowhead} arrowhead and {arrow.Fletching} fletching will cost you {arrow.GetCost():0.00} gold");



// Classes
class Arrow
{
    // Properties
    public Arrowhead Arrowhead { get; set; }
    public Fletching Fletching { get; set; }
    public int Shaft { get; set; }


    // Constructors
    public Arrow() { }

    public Arrow(Arrowhead arrowhead, Fletching fletching, int shaft)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Shaft = shaft;
    }


    // Methods
    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.Goose, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.Goose, 65);

    public float GetCost()
    {
        float price = Arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
        };

        price += Fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.Turkey => 5,
            Fletching.Goose => 3,
        };

        price += Shaft * 0.05f;

        return price;
    }
}



// Enums
enum Arrowhead { Steel, Wood, Obsidian }
enum Fletching { Plastic, Turkey, Goose }