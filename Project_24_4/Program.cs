//  - Additionally, you should be able to change the passcode by supplying the current code and a new
//    one.The passcode should only change if the correct, current code is given.
//  - Objectives:
//    - Build a method that will allow you to change the passcode for an existing door by supplying the
//      current passcode and new passcode.Only change the passcode if the current passcode is correct.
//    - Make your main method ask the user for a starting passcode, then create a new Door instance.Allow
//      the user to attempt the four transitions described above (open, close, lock, unlock, newCode, exit, ) and change the
//      code by typing in text commands.


string code;

Console.Write("Enter new code: ");
code = Console.ReadLine();
Door door = new(code);

string input = "";

do
{
    Console.Clear();
    Console.WriteLine($"The door is {door.DoorState} and {door.LockState}");
    Console.WriteLine("\nUse the commands: open, close, lock, unlock, newCode, exit");
    Console.Write("Command: ");
    input = Console.ReadLine()!;

    string newCode, oldCode;

    switch (input)
    {
        case "open":
            door.Open();
            break;
        case "close":
            door.Close();
            break;
        case "lock":
            door.Lock();
            break;
        case "unlock":
            Console.Write("Code: ");
            newCode = Console.ReadLine();
            door.Unlock(newCode);
            break;
        case "newCode":
            Console.Write("Current code: ");
            oldCode = Console.ReadLine();
            Console.Write("New code: ");
            newCode = Console.ReadLine();
            if (door.ChangeCode(oldCode, newCode)) Console.WriteLine("Code changed! Press Any Key to continue");
            else Console.WriteLine("Code could NOT be changed! Press Any Key to continue");
            Console.ReadKey(true);
            break;
        default:
            break;
    }

} while (input != "exit");


// Classes
internal class Door
{
    // Fields
    private string code;


    // Properties
    public DoorStates DoorState { get; private set;}
    public LockStates LockState { get; private set; }    


    // Constructors
    public Door(string code)
    {
        this.code = code;
        DoorState = DoorStates.Closed;
        LockState = LockStates.Locked;
    }


    // Methods
    public void Open()
    {
        if (DoorState == DoorStates.Closed && LockState == LockStates.Unlocked) DoorState = DoorStates.Open;
    }

    public void Close()
    {
        if (DoorState == DoorStates.Open) DoorState = DoorStates.Closed;
    }

    public void Lock()
    {
        if (DoorState == DoorStates.Closed) LockState = LockStates.Locked;
    }

    public void Unlock(string code)
    {
        if (this.code == code) LockState = LockStates.Unlocked;
    }

    public bool ChangeCode(string oldCode, string newCode)
    {
        if (oldCode == code)
        {
            code = newCode;
            return true;
        }

        return false;
    }
}


// Enums
enum DoorStates { Open, Closed}
enum LockStates { Unlocked, Locked}


