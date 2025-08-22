//  Create Player – With name, level, and score.
//  Create Book – Title, author, pages.
//  Display Object Info – Print object data with method.
//  Compare Two Books – Check which has more pages.
//  Inventory List – Use class to hold multiple item objects.


Book book1 = new("Beasts of the Moor", "Geralt of Rivia", 312);
Book book2 = new("Dead beasts of the Moor", "Ciri", 128);

Console.WriteLine("The Books:");
Console.WriteLine(book1.Info());
Console.WriteLine(book2.Info());

if(book1.pages > book2.pages)
{
    Console.WriteLine($"{book1.title} has the most pages ({book1.pages})");
}
else
{
    Console.WriteLine($"{book2.title} has the most pages ({book2.pages})");
}

Item item1 = new("A black stone");
Item item2 = new("A hammer");
Item item3 = new("A very nice stick");
Item item4 = new("A pair of scissors");

Inventory backpack = new Inventory(10);

Console.WriteLine();
Console.WriteLine("The Inventory:");

backpack.AddItem(item1);
backpack.AddItem(item2);
backpack.AddItem(item3);
backpack.AddItem(item4);

backpack.ShowItems();



// Classes
class Player
{
    public string name;
    public int level;
    public int score;

    public Player (string name, int level, int score)
    {
        this.name = name;
        this.level = level;
        this.score = score;
    }

    public string Info()
    {
        return $"Player: {name}  Level: {level}  Score: {score}";
    }
}

class Book
{
    public string title;
    public string author;
    public int pages;

    public Book(string title, string author, int pages)
    {
        this .title = title;
        this .author = author;
        this .pages = pages;
    }

    public string Info()
    {
        return $"Title: {title}  Author: {author}  Page: {pages}";
    }

}

class Item
{
    public string name;

    public Item(string name)
    {
        this.name = name;
    }
}


class Inventory
{
    // A list to hold the objects would be better, but since the book hasn't covered that yet I goo with an array
    public Item[] items;
    int position;

    public Inventory(int size)
    {
        items = new Item[size];
        position = -1;
    }

    // I skip removing items
    public bool AddItem(Item item)
    {
        if (position == items.Length - 1)
        {
            return false;
        }
        else
        {
            position++;
            items[position] = item;
            return true;
        }
    }

    public void ShowItems()
    {
        for (int i = 0; i <= position; i++)
        {
            Console.WriteLine(items[i].name);
        }
    }
}