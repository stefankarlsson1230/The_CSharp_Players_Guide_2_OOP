using static System.Console;

// Setup
string input = "";
Game game = null;

while (input == "")
{
    Write("Do you want a small (4x4), medium (6x6) or large (8x8) world? ");
    input = ReadLine()!.ToLower();

    switch (input)
    {
        case "small":
            game = new(GameSize.Small);
            break;
        case "medium":
            game = new(GameSize.Medium);
            break;
        case "large":
            game = new(GameSize.Large);
            break;
        default:
            input = "";
            break;
    }
}

Clear();


// Instructions
int width = Console.WindowWidth;
string lineDivider = new string('-', width);

ForegroundColor = ConsoleColor.White;
WriteLine("The Fountain of Objects game is a 2D grid-based world full of rooms. ");
WriteLine("The objective is to find the fountain room, activate it, and then find your way back to the entrance room.");
WriteLine("Unnatural darkness pervades the caverns, preventing both natural and human-made light. The player must ");
WriteLine("navigate the caverns in the dark, relying on their sense of smell and hearing to determine what room");
WriteLine("they are in and what dangers lurk in nearby rooms.");

WriteLine(lineDivider);

WriteLine("Commands:  \"move north\", \"move south\", \"move east\", \"move west\", \"enable fountain\"");


// Gameloop
Room currentRoom;

while (true)
{
    currentRoom = game!.Map.GetRoom(game.Position);

    ForegroundColor = ConsoleColor.Gray;
    WriteLine(lineDivider);
    WriteLine($"You are in the room at (Row = {game.Position.Row}, Column = {game.Position.Col}).");

    // check for win condition
    if (currentRoom.RoomType == RoomType.Entrance && game.FountainActive)
    {
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        WriteLine("You win!");
        break;
    }

    // Check for loose condition
    if (currentRoom.RoomType == RoomType.Pit)
    {
        ForegroundColor = currentRoom.Color;
        WriteLine(currentRoom.Description);
        break;
    }

    //  Check for adjacent pits
    if (game.IsAdjacent(RoomType.Pit))
    {
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("You feel a draft. There is a pit in a nearby room.");
    }

    // Descriptions of current room
    if (currentRoom.RoomType != RoomType.Empty)
    {
        ForegroundColor = currentRoom.Color;
        WriteLine(currentRoom.Description);
    }

    // Player input
    ForegroundColor = ConsoleColor.Gray;
    Write("What do you want to do? ");
    ForegroundColor = ConsoleColor.Cyan;
    input = ReadLine()!.ToLower();

    switch (input)
    {
        case "move north":
            game.Move(new Position(game.Position.Row - 1, game.Position.Col));
            break;
        case "move south":
            game.Move(new Position(game.Position.Row + 1, game.Position.Col));
            break;
        case "move east":
            game.Move(new Position(game.Position.Row, game.Position.Col + 1));
            break;
        case "move west":
            game.Move(new Position(game.Position.Row, game.Position.Col - 1));
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
    public Position Position { get; private set; }  // Current position
    
    public bool FountainActive { get; set; }
    public Map Map { get; }


    // Constructor
    public Game(GameSize size)
    {
        FountainActive = false;
        Map = new Map(size);
        Position = Map.StartPos;
    }

    // Methods
    public void Move(Position pos)
    {
        Position.Row = Math.Clamp(pos.Row, 0, Map.RowSize - 1);
        Position.Col = Math.Clamp(pos.Col, 0, Map.ColSize - 1);
    }

    public bool IsAdjacent(RoomType roomType)     // Check if the specified roomtype is adjacent to the player position
    {
        Position pos1 = new Position(Math.Clamp(Position.Row - 1, 0, Map.RowSize - 1), Math.Clamp(Position.Col, 0, Map.ColSize - 1));
        Position pos2 = new Position(Math.Clamp(Position.Row - 1, 0, Map.RowSize - 1), Math.Clamp(Position.Col + 1, 0, Map.ColSize - 1));
        Position pos3 = new Position(Math.Clamp(Position.Row, 0, Map.RowSize - 1), Math.Clamp(Position.Col + 1, 0, Map.ColSize - 1));
        Position pos4 = new Position(Math.Clamp(Position.Row + 1, 0, Map.RowSize - 1), Math.Clamp(Position.Col + 1, 0, Map.ColSize - 1));
        Position pos5 = new Position(Math.Clamp(Position.Row + 1, 0, Map.RowSize - 1), Math.Clamp(Position.Col, 0, Map.ColSize - 1));
        Position pos6 = new Position(Math.Clamp(Position.Row +1, 0, Map.RowSize - 1), Math.Clamp(Position.Col - 1, 0, Map.ColSize - 1));
        Position pos7 = new Position(Math.Clamp(Position.Row, 0, Map.RowSize - 1), Math.Clamp(Position.Col - 1, 0, Map.ColSize - 1));
        Position pos8 = new Position(Math.Clamp(Position.Row - 1, 0, Map.RowSize - 1), Math.Clamp(Position.Col - 1, 0, Map.ColSize - 1));

        Position[] positions = [pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8];

        foreach(Position pos in positions)
        {
            if (pos != Position)    // Don´t want to check at the players current position
            {
                if (Map.GetRoom(pos).RoomType == roomType) return true;
            }
        }

        return false;
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
    public Position StartPos { get; } // Position of Entrance


    // Constructor
    public Map(GameSize size) // Fixed map based on size
    {
        switch (size)
        {
            case GameSize.Small:
                RowSize = 4;
                ColSize = 4;
                break;
            case GameSize.Medium:
                RowSize = 6;
                ColSize = 6;
                break;
            case GameSize.Large:
                RowSize = 8;
                ColSize = 8;
                break;
        }

        // Add Empty rooms to all positions
        rooms = new Room[RowSize, ColSize];

        for (int i = 0; i < RowSize; i++)
        {
            for (int j = 0; j < ColSize; j++)
            {
                rooms[i, j] = new Room(RoomType.Empty);
            }
        }

        // Set startposition and add rooms based on size of map
        switch (size)
        {
            case GameSize.Small:
                AddRoom(new Position(0, 0), RoomType.Entrance);
                StartPos = new Position(0, 0);
                AddRoom(new Position(1, 2), RoomType.Fountain);
                AddRoom(new Position(3, 2), RoomType.Pit);
                break;
            case GameSize.Medium:
                AddRoom(new Position(5, 0), RoomType.Entrance);
                StartPos = new Position(5, 0);
                AddRoom(new Position(2, 4), RoomType.Fountain);
                AddRoom(new Position(0, 2), RoomType.Pit);
                AddRoom(new Position(3, 0), RoomType.Pit);
                break;
            case GameSize.Large:
                AddRoom(new Position(3, 7), RoomType.Entrance);
                StartPos = new Position(3, 7);
                AddRoom(new Position(4, 2), RoomType.Fountain);
                AddRoom(new Position(0, 5), RoomType.Pit);
                AddRoom(new Position(3, 2), RoomType.Pit);
                AddRoom(new Position(4, 5), RoomType.Pit);
                AddRoom(new Position(7, 0), RoomType.Pit);
                break;
        }
    }

    // Methods
    public void AddRoom(Position pos, RoomType roomType)
    {
        rooms[pos.Row, pos.Col] = new Room(roomType);
    }

    public Room GetRoom(Position pos)
    {
        return rooms[pos.Row, pos.Col];
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
            RoomType.Pit => "You stumble down a bottomless pit! \nGame over!",
        };

        Color = roomType switch
        {
            RoomType.Empty => ConsoleColor.Gray,
            RoomType.Entrance => ConsoleColor.Yellow,
            RoomType.Fountain => ConsoleColor.Blue,
            RoomType.Pit => ConsoleColor.DarkGray,
        };
    }
}

public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Position(int row, int col)
    {
        Row = row; 
        Col = col;
    }
}


// Enums
public enum RoomType { Empty, Entrance, Fountain, Pit }
public enum GameSize { Small, Medium, Large }



