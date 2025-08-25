// Modify your Arrow class to have private instead of public fields.
// Add in getter methods for each of the fields that you have.

Arrow arrow = new();
int input = -1;

while (input < 1 || input > 3)
{
    Console.Write("Choose arrowhead (1. Steel, 2. Wood, 3. Obsidian): ");
    input = int.Parse(Console.ReadLine());
}

switch (input)
{
    case 1:
        arrow.SetArrowHead(Arrowhead.Steel);
        break;
    case 2:
        arrow.SetArrowHead(Arrowhead.Wood);
        break;
    case 3:
        arrow.SetArrowHead(Arrowhead.Obsidian);
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
        arrow.SetFletching(Fletching.Plastic);
        break;
    case 2:
        arrow.SetFletching(Fletching.Turkey);
        break;
    case 3:
        arrow.SetFletching(Fletching.Goose);
        break;
}


while (input < 60 || input > 100)
{
    Console.Write("Choose shaft-legth (60 - 100 cm): ");
    input = int.Parse(Console.ReadLine());
}

arrow.SetShaft(input);

Console.WriteLine($"Your {arrow.GetShaft()} cm long arrow, with a {arrow.GetArrowhead()} arrowhead and {arrow.GetFletching()} fletching will cost you {arrow.GetCost():0.00} gold");



// Classes
class Arrow
{
    private Arrowhead arrowhead;
    private Fletching fletching;
    private int shaft;

    // Constructors
    public Arrow() { }

    public Arrow(Arrowhead arrowhead, Fletching fletching, int shaft)
    {
        this.arrowhead = arrowhead;
        this.fletching = fletching;
        this.shaft = shaft;
    }

    // Getters & Setters
    public void SetArrowHead(Arrowhead arrowhead)
    {
        this.arrowhead = arrowhead;
    }

    public void SetFletching(Fletching fletching)
    {
        this.fletching = fletching;
    }

    public void SetShaft(int shaft)
    {
        this.shaft = shaft;
    }



    public Arrowhead GetArrowhead() => arrowhead;
    public Fletching GetFletching() => fletching;
    public int GetShaft() => shaft;

    public float GetCost()
    {
        float price = arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
        };

        price += fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.Turkey => 5,
            Fletching.Goose => 3,
        };

        price += shaft * 0.05f;

        return price;
    }
}



// Enums
enum Arrowhead { Steel, Wood, Obsidian }
enum Fletching { Plastic, Turkey, Goose }