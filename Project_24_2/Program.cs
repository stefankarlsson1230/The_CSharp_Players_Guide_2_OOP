
Color a = new(50, 150, 250);
Color b = Color.Orange;


Console.WriteLine("Color a ");
Console.WriteLine($"Red: {a.R}  Green: {a.G}  Blue: {a.B}");
Console.WriteLine();

Console.WriteLine("Color b ");
Console.WriteLine($"Red: {b.R}  Green: {b.G}  Blue: {b.B}");



// Classes
internal class Color
{
    // Properties
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    // Static Properties
    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; }  = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; }  = new Color(255, 255, 0);
    public static Color Green { get; }  = new Color(0, 128, 0);
    public static Color Purple { get; }  = new Color(128, 0, 128);


    // Constructors
    public Color ()
    {
        R = 0;
        G = 0;
        B = 0;
    }
    
    public Color (byte red, byte green, byte blue)
    {
        R = red;
        G = green;
        B = blue;
    }

}