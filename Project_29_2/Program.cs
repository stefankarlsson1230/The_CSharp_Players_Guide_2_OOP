//  Equality Test – Compare two records.
Contact person1 = new("Totte", "123-455677");
Contact person2 = new("Totte", "123-455677");
Contact person3 = new("Fabian", "123-455677");

Console.WriteLine($"{nameof(person1)} : {person1}");
Console.WriteLine($"{nameof(person2)} : {person2}");
Console.WriteLine($"{nameof(person3)} : {person3}");

Console.WriteLine();

if (person1 == person2) Console.WriteLine($"{nameof(person1)} and {nameof(person2)} are the same person!");
else Console.WriteLine($"{nameof(person1)} and {nameof(person2)} are NOT the same person!");

if (person1 == person3) Console.WriteLine($"{nameof(person1)} and {nameof(person3)} are the same person!");
else Console.WriteLine($"{nameof(person1)} and {nameof(person3)} are NOT the same person!");

Console.WriteLine();


//  With Expression – Clone record and change one field.
Console.WriteLine("Using: person2 = person3 with { Name = \"Olle\" };");

person2 = person3 with { Name = "Olle" };
Console.WriteLine($"{nameof(person2)} : {person2}");
Console.WriteLine($"{nameof(person3)} : {person3}");


// Records
public record Contact(string Name, string Phone);   //  Contact Record – With Name, Phone.

