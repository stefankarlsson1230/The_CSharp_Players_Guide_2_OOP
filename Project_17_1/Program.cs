
(Type type, Main main, Seasoning seasoning) soup;


soup = (ChooseType(), ChooseMain(), ChooseSeasoning());

Console.WriteLine($"{soup.seasoning} {soup.main} {soup.type}");




// Local functions
Type ChooseType()
{
    int choice = 0;

    while(choice < 1 || choice > 3)
    {
        Console.Write("Type of food (1. Soup, 2. Stew, 3. Gumbo): ");
        choice = int.Parse(Console.ReadLine());
        Console.Clear();
    }

    return choice switch
    {
        1 => Type.Soup,
        2 => Type.Stew,
        3 => Type.Gumbo,
    };
}

Main ChooseMain()
{
    int choice = 0;

    while (choice < 1 || choice > 4)
    {
        Console.Write("Main ingredient (1. Mushrooms, 2. Chicken, 3. Carrots, 4. Potatoes): ");
        choice = int.Parse(Console.ReadLine());
        Console.Clear();
    }

    return choice switch
    {
        1 => Main.Mushroom,
        2 => Main.Chicken,
        3 => Main.Carrot,
        4 => Main.Potatoe,
    };
}

Seasoning ChooseSeasoning()
{
    int choice = 0;

    while (choice < 1 || choice > 3)
    {
        Console.Write("Seasoning (1. Spicy, 2. Salty, 3. Sweet): ");
        choice = int.Parse(Console.ReadLine());
        Console.Clear();
    }

    return choice switch
    {
        1 => Seasoning.Spicy,
        2 => Seasoning.Salty,
        3 => Seasoning.Sweet,
    };
}



// Enums
enum Type { Soup, Stew, Gumbo}
enum Main { Mushroom, Chicken, Carrot, Potatoe}
enum Seasoning { Spicy, Salty, Sweet}
