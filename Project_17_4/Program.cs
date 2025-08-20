// Rectangle Info - Return area and perimeter as tuple.

double length, width;

Console.Write("Length: ");
length = double.Parse(Console.ReadLine());

Console.Write("Width: ");
width = double.Parse(Console.ReadLine());


(double area, double perimeter) = GetRectangleInfo(length, width);

Console.WriteLine($"Area: {area}");
Console.WriteLine($"Perimeter: {perimeter}");


// Local Functions
(double area, double perimeter) GetRectangleInfo(double length, double width) => (length *  width, length * 2 + width * 2);

