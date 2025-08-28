
Point a = new(2, 3);
Point b = new(-4, 0);

Console.WriteLine(a.ToString());
Console.WriteLine(b.ToString());


// Classes
internal class Point
{
    // Properties
    public int X { get; }
    public int Y { get; }


    // Constructors
    public Point() : this(0, 0)
    { 
    }
    
    public Point (int x, int y)
    {
        X = x;
        Y = y;
    }


    // Methods
    public string ToString()
    {
        return $"({this.X}, {this.Y})";
    }
}