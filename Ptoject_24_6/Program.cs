// This implementation is hardcoded for the size 3 x 3
// I began by working on a more general model, but I feel it takes to much effeort for this assignment.

Board board = new();
Player player1 = new('X');
Player player2 = new('O');

Player[] players = { player1, player2 };

int input;
string state;

// Gameloop
while(true)
{
    foreach(Player player in players)
    {
        Console.Clear();
        Console.WriteLine($"It is {player.Marker}'s turn.");
        board.DrawBoard();

        // Place the marker
        do
        {
            Console.Write("Place your marker with the numpad: ");
            input = int.Parse(Console.ReadLine());          // This could fail I know...

            if (input < 1 || input > 9)
            {
                input = -1;
                Console.WriteLine("Use the numpad (1 - 9)");
            }
            else if (!player.Play(board, input, player.Marker))
            {
                input = -1;
                Console.WriteLine("This spot is already taken!");
            }
        }
        while (input == -1);


        // Check for win or draw
        state = board.State(player.Marker);

        switch (state)
        {
            case "win":
                Console.Clear();
                Console.WriteLine();
                board.DrawBoard();
                Console.WriteLine($"\nCongratulations! {player.Marker} is the winner!\n");
                return;
            case "draw":
                Console.Clear();
                Console.WriteLine();
                board.DrawBoard();
                Console.WriteLine($"\nIt's a draw\n");
                return;
            default:
                break;
        }
    }
}


// ---------- Classes ----------

internal class Board
{
    // Fields
    private readonly char[,] _board;

    // Constructors
    public Board()
    {
        _board = new char[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                _board[i, j] = ' ';
            }
        }
    }

    // Methods
    public void DrawBoard()
    {
        string row;

        for (int i = 0; i < 3; i++)
        {
            row = String.Empty;

            for (int j = 0; j < 3; j++)
            {
                row += $" {_board[i, j]} ";
                if(j != 2) row += "|";
            }
            
            if (i != 2)
            {
                row += '\n';
                for (int j = 0; j < 3; j++)
                {
                    row += $"---";
                    if (j != 2) row += "+";
                }
            }

            Console.WriteLine(row);
        }
    }

    public bool Play(int row, int col, char marker)      // Input coordinates. Return true if legal move
    {
        if(_board[row, col] != ' ') return false;
        else
        {
            _board[row, col] = marker;
            return true;
        }
    }

    public string State(char marker)   // Returns "win", "draw" or "undecided"
    {
        // Check for win (this is not checked before one player has put a mark)
        if ((_board[0, 0] == marker) && (_board[1, 1] == marker) && (_board[2, 2] == marker)) return "win";
        if ((_board[0, 2] == marker) && (_board[1, 1] == marker) && (_board[2, 0] == marker)) return "win";

        if ((_board[0, 0] == marker) && (_board[0, 1] == marker) && (_board[0, 2] == marker)) return "win";
        if ((_board[1, 0] == marker) && (_board[1, 1] == marker) && (_board[1, 2] == marker)) return "win"; 
        if ((_board[2, 0] == marker) && (_board[2, 1] == marker) && (_board[2, 2] == marker)) return "win";

        if ((_board[0, 0] == marker) && (_board[1, 0] == marker) && (_board[2, 0] == marker)) return "win"; 
        if ((_board[0, 1] == marker) && (_board[1, 1] == marker) && (_board[2, 1] == marker)) return "win";
        if ((_board[0, 2] == marker) && (_board[1, 2] == marker) && (_board[2, 2] == marker)) return "win";

        // Check for draw or undecided
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board[i, j] == ' ') return "undecided";
            }
        }
        return "draw";
    }
}


internal class Player
{
    // Properties
    public char Marker { get; }

    // Constructors
    public Player(char marker)
    {
        Marker = marker;
    }

    // Methods
    public bool Play(Board board, int numpad, char Marker)    // Returns true if legal move
    {
        switch (numpad)
        {
            case 1:
                return board.Play(2, 0, Marker);
            case 2:
                return board.Play(2, 1, Marker);
            case 3:
                return board.Play(2, 2, Marker);
            case 4:
                return board.Play(1, 0, Marker);
            case 5:
                return board.Play(1, 1, Marker);
            case 6:
                return board.Play(1, 2, Marker);
            case 7:
                return board.Play(0, 0, Marker);
            case 8:
                return board.Play(0, 1, Marker);
            case 9:
                return board.Play(0, 2, Marker);
            default:
                return false;
        }
    }
}



