// I changed some colors that are hard to read

int width = Console.WindowWidth;
string lineDivider = new string('-', width);

// Instructions
Console.ForegroundColor = ConsoleColor.White;
WriteLine("The Fountain of Objects game is a 2D grid-based world full of rooms. ");
WriteLine("The objective is to find the fountain room, activate it, and then find your way back to the entrance room.");
WriteLine("Unnatural darkness pervades the caverns, preventing both natural and human-made light. The player must ");
WriteLine("navigate the caverns in the dark, relying on their sense of smell and hearing to determine what room");
WriteLine("they are in and what dangers lurk in nearby rooms.");

WriteLine(lineDivider);

WriteLine("Commands:  \"move north\", \"move south\", \"move east\", \"move west\", \"enable fountain\"");

// Initializing the game
Game game = new(4, 4);
game.Map.AddRoom(0, 0, RoomType.Entrance);
game.Map.AddRoom(0, 2, RoomType.Fountain);


// Gameloop
Room currentRoom;
string input;

while(true)
{
    currentRoom = game.Map.GetRoom(game.Row, game.Col);

    ForegroundColor = ConsoleColor.Gray;
    WriteLine(lineDivider);
    WriteLine($"You are in the room at (Row = {game.Row}, Column = {game.Col}).");

    // check fo win
    if(currentRoom.RoomType == RoomType.Entrance && game.FountainActive)
    {
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        WriteLine("You win!");
        break;
    }

    if (currentRoom.RoomType != RoomType.Empty)
    {
        ForegroundColor = currentRoom.Color;
        WriteLine(currentRoom.Description);
    }

    ForegroundColor = ConsoleColor.Gray;
    Write("What do you want to do? ");
    ForegroundColor = ConsoleColor.Cyan;
    input = ReadLine()!.ToLower();

    switch (input)
    {
        case "move north":
            game.Move(game.Row - 1, game.Col);
            break;
        case "move south":
            game.Move(game.Row + 1, game.Col);
            break;
        case "move east":
            game.Move(game.Row, game.Col + 1);
            break;
        case "move west":
            game.Move(game.Row, game.Col - 1);
            break;
        case "enable fountain":
            if (currentRoom.RoomType == RoomType.Fountain)
            {
                game.FountainActive = true;
                currentRoom.Description = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
            }
            else
            {
                WriteLine("It has no effect!");
            }
                break;
        default:
            break;
    }

}

ForegroundColor = ConsoleColor.Gray;    // Reset to standard color


// Classes

public class Game
{
    // Properties
    public int Row { get; private set; }   // Current Row
    public int Col { get; private set; }    // Current Column

    public bool FountainActive { get; set; }
    public Map Map { get; }
   

    // Constructor
    public Game(int rows, int cols)
    {
        Map = new Map(rows, cols);
        FountainActive = false;
        Row = 0; 
        Col = 0;
    }

    // Methods
    public void Move(int row, int col)
    {
        Row = Math.Clamp(row, 0, Map.RowSize - 1);
        Col = Math.Clamp(col, 0, Map.ColSize - 1);
    }
}


// The map grid is counting from the top left corner [0,0] - Columns increases to the right, Rows increases downward
public class Map
{
    // Fields
    private Room[,] rooms;

    // Properties
    public int RowSize { get; }    // Number of Columns on the map
    public int ColSize { get; }    // Number of Rows on the map

    // Constructor - Fills the map with empty rooms
    public Map(int rowSize, int colSize)          
    {
        RowSize = rowSize;
        ColSize = colSize;

        rooms = new Room[rowSize, colSize];

        for (int i = 0; i < rowSize; i++)
        {
            for (int j = 0; j < colSize; j++)
            {
                rooms[i, j] = new Room(RoomType.Empty);
            }
        }
    }

    // Methods
    public void AddRoom(int row, int col, RoomType roomType)
    {
        rooms[row, col] = new Room(roomType);
    }

    public Room GetRoom(int row, int col)
    {
        return rooms[row, col];
    }

}

public class Room
{
    public string Description { get; set; }
    public RoomType RoomType { get; }
    public ConsoleColor Color { get; }


    public Room(RoomType roomType)
    {
        RoomType = roomType;

        Description = roomType switch
        {
            RoomType.Empty => "",
            RoomType.Entrance => "You see light coming from the cavern entrance.",
            RoomType.Fountain => "You hear water dripping in this room. The Fountain of Objects is here!",
        };

        Color = roomType switch
        {
            RoomType.Empty => ConsoleColor.Gray,
            RoomType.Entrance => ConsoleColor.Yellow,
            RoomType.Fountain => ConsoleColor.Blue,
        };
    }
}



// Enums
public enum RoomType { Empty, Entrance, Fountain }




