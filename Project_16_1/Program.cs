ChestState chestState = ChestState.Locked;
string input;

while(true)
{
    Console.Write($"The chest is {chestState}. What do you want to do? ");
    input = Console.ReadLine();

    if(input == "unlock")
    {
        if (chestState == ChestState.Locked)
        {
            chestState = ChestState.Unlocked;
        }
    }
    else if (input == "open")
    {
        if (chestState == ChestState.Unlocked)
        {
            chestState = ChestState.Open;
        }
    }
    else if (input == "close")
    {
        if (chestState == ChestState.Open)
        {
            chestState = ChestState.Unlocked;
        }
    }
    else if (input == "lock")
    {
        if (chestState == ChestState.Unlocked)
        {
            chestState = ChestState.Locked;
        }
    }
}


// Enums
enum ChestState {Open, Unlocked, Locked }
