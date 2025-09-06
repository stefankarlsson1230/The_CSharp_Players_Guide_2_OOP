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
WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous \npits in search of the Fountain of Objects.");
WriteLine("Light is visible only in the entrance, and no other light is seen anywhere\nin the caverns.");
WriteLine("You must navigate the Caverns with your other senses.");
WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
WriteLine("- Look out for pits. You will feel a breeze if a pit is in an adjacent room. \nIf you enter a room with a pit, you will die.");
WriteLine("- Maelstroms are violent forces of sentient wind. Entering a room with one \ncould transport you to any other location in the caverns. You will be able \nto hear their growling and groaning in nearby rooms.");
WriteLine("- Amaroks roam the caverns. Encountering one is certain death, but you can \nsmell their rotten stench in nearby rooms.");
WriteLine("- You carry with you a bow and a quiver of arrows. You can use them to shoot \nmonsters in the caverns but be warned: you have a limited supply.");
WriteLine("- Enter \"help\" to get a list of commands.");


// Gameloop
Room currentRoom;

while (true)
{
    currentRoom = game!.Map.GetRoom(game.Position);

    ForegroundColor = ConsoleColor.Gray;
    WriteLine(lineDivider);
    WriteLine($"You are in the room at (Row = {game.Position.Row}, Column = {game.Position.Col}) Arrows left: {game.Arrows}");

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
    else if (currentRoom.RoomType == RoomType.Amarok)
    {
        ForegroundColor = currentRoom.Color;
        WriteLine(currentRoom.Description);
        break;
    }

    // Descriptions of current room
    if (currentRoom.RoomType != RoomType.Empty)
    {
        ForegroundColor = currentRoom.Color;
        WriteLine(currentRoom.Description);

        if (currentRoom.RoomType == RoomType.Maelstrom)
        {
            game.Maelstrom();
            continue;
        }
    }

    //  Check for adjacent pits
    if (game.IsAdjacent(RoomType.Pit))
    {
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("You feel a draft. There is a pit in a nearby room.");
    }

    // Check for adjacent Maelstrom
    if (game.IsAdjacent(RoomType.Maelstrom))
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("You hear the growling and groaning of a maelstrom nearby.");
    }

    // Check for adjacent Amaroks
    if (game.IsAdjacent(RoomType.Amarok))
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("You can smell the rotten stench of an amarok in a nearby room.");
    }

    // Player input
    ForegroundColor = ConsoleColor.Gray;
    Write("What do you want to do? ");
    ForegroundColor = ConsoleColor.Cyan;
    input = ReadLine()!.ToLower();

    switch (input)
    {
        case "help":
            WriteLine(lineDivider);
            WriteLine("help\nmove north\nmove south\nmove east\nmove west\nshoot north\nshoot south\nshoot east\nshoot west\nenable fountain");
            break;
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
        case "shoot north":
            game.ShootAt(new Position(game.Position.Row - 1, game.Position.Col));
            break;
        case "shoot south":
            game.ShootAt(new Position(game.Position.Row + 1, game.Position.Col));
            break;
        case "shoot east":
            game.ShootAt(new Position(game.Position.Row, game.Position.Col + 1));
            break;
        case "shoot west":
            game.ShootAt(new Position(game.Position.Row, game.Position.Col - 1));
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
    public int Arrows { get; private set; }


    // Constructor
    public Game(GameSize size)
    {
        FountainActive = false;
        Map = new Map(size);
        Position = Map.StartPos;
        Arrows = 5;
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
        Position pos6 = new Position(Math.Clamp(Position.Row + 1, 0, Map.RowSize - 1), Math.Clamp(Position.Col - 1, 0, Map.ColSize - 1));
        Position pos7 = new Position(Math.Clamp(Position.Row, 0, Map.RowSize - 1), Math.Clamp(Position.Col - 1, 0, Map.ColSize - 1));
        Position pos8 = new Position(Math.Clamp(Position.Row - 1, 0, Map.RowSize - 1), Math.Clamp(Position.Col - 1, 0, Map.ColSize - 1));

        Position[] positions = [pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8];

        foreach (Position pos in positions)
        {
            if (Map.GetRoom(pos).RoomType == roomType) return true;
        }

        return false;
    }

    public void Maelstrom()
    {
        // This will replace the current room with a maelstrom, which if you are unlucky could replace the entrance/fountain room.
        // I will ignore this flaw in this implementation
        Map.AddRoom(Position, RoomType.Empty);
        Map.AddRoom(new Position(Position.Row + 1, Position.Col - 2), RoomType.Maelstrom);
        Move(new Position(Position.Row - 1, Position.Col + 2));
    }

    public void ShootAt(Position pos)
    {
        if (Arrows == 0)
        {
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("You have no arrows left!");
            return;
        }

        // Make sure not to shoot outside of the map
        int row = Math.Clamp(pos.Row, 0, Map.RowSize - 1);
        int col = Math.Clamp(pos.Col, 0, Map.ColSize - 1);

        pos = new Position(row, col);
        Room room = Map.GetRoom(pos);

        if (room.RoomType == RoomType.Amarok || room.RoomType == RoomType.Maelstrom) Map.AddRoom(pos, RoomType.Empty);

        Arrows--;
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
                StartPos = new Position(0, 0);
                AddRoom(new Position(0, 0), RoomType.Entrance);
                AddRoom(new Position(1, 2), RoomType.Fountain);
                AddRoom(new Position(3, 2), RoomType.Pit);
                AddRoom(new Position(2, 0), RoomType.Maelstrom);
                AddRoom(new Position(0, 3), RoomType.Amarok);
                break;
            case GameSize.Medium:
                StartPos = new Position(5, 0);
                AddRoom(new Position(5, 0), RoomType.Entrance);
                AddRoom(new Position(2, 4), RoomType.Fountain);
                AddRoom(new Position(0, 2), RoomType.Pit);
                AddRoom(new Position(3, 0), RoomType.Pit);
                AddRoom(new Position(2, 2), RoomType.Maelstrom);
                AddRoom(new Position(1, 0), RoomType.Amarok);
                AddRoom(new Position(5, 3), RoomType.Amarok);
                break;
            case GameSize.Large:
                StartPos = new Position(3, 7);
                AddRoom(new Position(3, 7), RoomType.Entrance);
                AddRoom(new Position(4, 2), RoomType.Fountain);
                AddRoom(new Position(0, 5), RoomType.Pit);
                AddRoom(new Position(3, 2), RoomType.Pit);
                AddRoom(new Position(4, 5), RoomType.Pit);
                AddRoom(new Position(7, 0), RoomType.Pit);
                AddRoom(new Position(1, 3), RoomType.Maelstrom);
                AddRoom(new Position(5, 5), RoomType.Maelstrom);
                AddRoom(new Position(1, 1), RoomType.Amarok);
                AddRoom(new Position(5, 2), RoomType.Amarok);
                AddRoom(new Position(7, 5), RoomType.Amarok);
                break;
        }
    }

    // Methods
    public void AddRoom(Position pos, RoomType roomType)
    {
        // Makes sure the room is placed on the map
        int row = Math.Clamp(pos.Row, 0, RowSize - 1);
        int col = Math.Clamp(pos.Col, 0, ColSize - 1);

        rooms[row, col] = new Room(roomType);
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
            RoomType.Amarok => "You are devoured by a giant, rotting, wolflike Amarok! \nGame Over!",
            RoomType.Empty => "",
            RoomType.Entrance => "You see light coming from the cavern entrance.",
            RoomType.Fountain => "You hear water dripping in this room. The Fountain of Objects is here!",
            RoomType.Maelstrom => "You are suddenly swept away by a Maelstrom!",
            RoomType.Pit => "You stumble down a bottomless pit! \nGame over!",
        };

        Color = roomType switch
        {
            RoomType.Amarok => ConsoleColor.Red,
            RoomType.Empty => ConsoleColor.Gray,
            RoomType.Entrance => ConsoleColor.Yellow,
            RoomType.Fountain => ConsoleColor.Blue,
            RoomType.Maelstrom => ConsoleColor.Green,
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
public enum RoomType { Amarok, Empty, Entrance, Fountain, Maelstrom, Pit }
public enum GameSize { Small, Medium, Large }




