//  Null Name Check – Warn if name is null.
string? name;

Console.Write("Name: ");
name = Console.ReadLine();

if (name == null)
{
    Console.WriteLine("Null warning!");
}
else
{
    Console.WriteLine("Your name is " + name);
}


//  Default Description – Use null-coalescing.
name = null;

name = name ?? "Null";
Console.WriteLine(name);

