//  Each arrow has three parts: the arrowhead(steel, wood, or obsidian), the shaft(a length between 60 and 100 cm long),
//  and the fletching (plastic, turkey feathers, or goose feathers).
//  His costs are as follows:
//  - For arrowheads, steel costs 10 gold, wood costs 3 gold, and obsidian costs 5 gold.
//  - For fletching, plastic costs 10 gold, turkey feathers cost 5 gold, and goose feathers cost 3 gold.
//  - For the shaft, the price depends on the length: 0.05 gold per centimeter.
//
//  Objectives:
//  - Define a new Arrow class with fields for arrowhead type, fletching type, and length. (Hint: arrowhead types and
//      fletching types might be good enumerations.)
//  - Allow a user to pick the arrowhead, fletching type, and length and then create a new Arrow instance.
//  - Add a GetCost method that returns its cost as a float based on the numbers above, and use this to display the arrow’s cost.


using System.Runtime.InteropServices;

Arrow arrow = new();
int input = -1;

while (input < 1 ||  input > 3)
{
    Console.Write("Choose arrowhead (1. Steel, 2. Wood, 3. Obsidian): ");
    input = int.Parse(Console.ReadLine());
}

switch (input)
{
    case 1:
        arrow.arrowhead = Arrowhead.Steel;
        break;
    case 2:
        arrow.arrowhead = Arrowhead.Wood;
        break;
    case 3:
        arrow.arrowhead = Arrowhead.Obsidian;
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
        arrow.fletching = Fletching.Plastic;
        break;
    case 2:
        arrow.fletching = Fletching.Turkey;
        break;
    case 3:
        arrow.fletching = Fletching.Goose;
        break;
}


while (input < 60 || input > 100)
{
    Console.Write("Choose shaft-legth (60 - 100 cm): ");
    input = int.Parse(Console.ReadLine());
}

arrow.shaft = input;

Console.WriteLine($"Your {arrow.shaft} cm long arrow, with a {arrow.arrowhead} arrowhead and {arrow.fletching} fletching will cost you {arrow.GetCost():0.00} gold");





// Classes
class Arrow
{
    public Arrowhead arrowhead;
    public Fletching fletching;
    public int shaft;

    // Constructors
    public Arrow() { }

    public Arrow(Arrowhead arrowhead, Fletching fletching, int shaft)
    {
        this.arrowhead = arrowhead;
        this.fletching = fletching;
        this.shaft = shaft;
    }

    // Methods
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
enum Arrowhead { Steel, Wood, Obsidian}
enum Fletching { Plastic, Turkey, Goose }

