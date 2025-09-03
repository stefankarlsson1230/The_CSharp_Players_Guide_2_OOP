Coordinate point1 = new Coordinate(1,1);
Coordinate point2 = new Coordinate(2,2);
Coordinate point3 = new Coordinate(2,3);
Coordinate point4 = new Coordinate(0,1);

Coordinate[] coordinates = [point1, point2, point3, point4]; 

foreach (Coordinate coord1 in coordinates)
{
    foreach (Coordinate coord2 in coordinates)
    {
        if (coord1.Adjacent(coord2)) Console.WriteLine(coord1 + " is adjacent to " + coord2);
    }
}


// Structs
public struct Coordinate
{
    // Properties
    public int Row { get; }
    public int Col { get; }


    // Constructors
    public Coordinate(int row, int col)
    {
        Row = row; 
        Col = col;
    }


    // Methods
    public bool Adjacent(Coordinate other)      // Not checking for diagonals
    {
        Coordinate point1 = new(Row, Col - 1);
        Coordinate point2 = new(Row + 1, Col);
        Coordinate point3 = new(Row, Col + 1);
        Coordinate point4 = new(Row - 1, Col);

        if(other.Equals(point1) || other.Equals(point2) || other.Equals(point3) || other.Equals(point4)) return true;
        else return false;
    }

    public override string ToString()
    {
        return $"[{this.Row}, {this.Col}]";
    }
}

