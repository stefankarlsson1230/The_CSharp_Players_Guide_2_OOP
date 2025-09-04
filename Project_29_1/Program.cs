Sword sword1 = new(Material.Iron, Gemstone.None, 100, 25);
Sword sword2 = sword1 with { Material = Material.Bronze };
Sword sword3 = sword2 with { Gemstone = Gemstone.Diamond, Length = 110 };

Console.WriteLine($"{nameof(sword1)} : {sword1}");
Console.WriteLine($"{nameof(sword2)} : {sword2}");
Console.WriteLine($"{nameof(sword3)} : {sword3}");


// Records
public record Sword(Material Material, Gemstone Gemstone, int Length, int CrossguardWidth);


// Enums
public enum Material { Wood, Bronze, Iron, Steel, Binarium}
public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None}


