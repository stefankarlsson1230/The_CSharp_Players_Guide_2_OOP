Pack pack = new(10, 8f, 8f);
string input;
InventoryItem? item;


while (true)
{
    Console.Clear();
    Console.WriteLine($"Status of the pack:  Items: {pack.NoOfItems}/{pack.Items.Length}  Weight: {pack.CurrentWeight:0.00}/{pack.MaxWeight:0.00}  Volume: {pack.CurrentVolume:0.00}/{pack.MaxVolume:0.00}");
    Console.WriteLine(pack.ToString());
    Console.WriteLine("Item you can add: 1.An Arrow  2.A Bow  3.A Rope  4.Water  5.Food  6.A Sword");
    Console.Write("Item: ");
    input = Console.ReadLine();

    item = input switch
    {
        "1" => new Arrow(),
        "2" => new Bow(),
        "3" => new Rope(),
        "4" => new Water(),
        "5" => new Food(),
        "6" => new Sword(),
        _ => null,
    };

    if (item == null)
    {
        Console.WriteLine("That is not a valid choice! Press any key to continue");
        Console.ReadKey();
    }
    else if (!pack.Add(item))
    {
        Console.WriteLine("Sorry that item will not fit in the pack! Press any key to continue");
        Console.ReadKey();
    }
}


// Classes
internal class InventoryItem
{
    // Properties
    public float Weight { get; private set; }
    public float Volume { get; private set; }

    // Constructors
    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}


internal class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString() => "Arrow";
}

internal class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
    public override string ToString() => "Bow";
}

internal class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
    public override string ToString() => "Rope";
}

internal class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
    public override string ToString() => "Water";
}

internal class Food : InventoryItem
{
    public Food() : base(1f, 0.5f) { }
    public override string ToString() => "Food";
}

internal class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
    public override string ToString() => "Sword";
}


internal class Pack
{
    // Properties
    public InventoryItem[] Items { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }

    public int NoOfItems { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }


    // Constructors
    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        Items = new InventoryItem[maxItems];
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        NoOfItems = 0;
        CurrentWeight = 0f;
        CurrentVolume = 0f;
    }


    // Methods
    public bool Add(InventoryItem item)
    {
        if ((Items.Length == NoOfItems) || (CurrentWeight + item.Weight > MaxWeight) || (CurrentVolume + item.Volume > MaxVolume))
        {
            return false;
        }
        else
        {
            Items[NoOfItems] = item;
            NoOfItems++;
            CurrentWeight += item.Weight;
            CurrentVolume += item.Volume;
            return true;
        }
    }

    public override string ToString()
    {
        string contents = "Pack containing:";

        for (int i = 0; i < NoOfItems; i++)
        {
            contents += " " + Items[i].ToString();
        }

        return contents;
    }

}