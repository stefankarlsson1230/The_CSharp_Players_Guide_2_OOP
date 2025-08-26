using System.Reflection;

//  Auto Property Player – Add Health, Mana, XP.
//  Read-Only ID – Use get only for a unique ID.
//  Validation – Set Age but block < 0.
//  Property Method – Calculate IsAlive from Health.
//  Display All Properties – Loop and print them.

Player player = new Player(100, 20, 2500, "Player_1", 25);


// The last assignment needs Reflection, which I know nothing about
// Had to ask ChatGPT about this one

Type type = player.GetType();

foreach(PropertyInfo prop in type.GetProperties())
{
    Console.WriteLine($"Property: {prop.Name}\t\t Value: {prop.GetValue(player)}");
}


// Classes

internal class Player
{
    // Fields
    public bool IsAlive = true;
    private int health;
    private int age;


    // Properties
    public int Health 
    {
        get
        {
            return health;
        }
        
        set
        {
            if (value <= 0) IsAlive = false;
            else IsAlive = true;
            health = value;
        }
    
    }
    public int Mana { get; set; }
    public int XP { get; set; }
    public string ID { get; }
    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            if (value < 0)
            {
                age = 0;
            }
            else
            {
                age = value;
            }

        }
    }


    // Constructor
    public Player (int health, int mana, int xp, string id, int age )
    {
        Health = health;
        Mana = mana;
        XP = xp;
        ID = id;
        Age = age;
    }
}