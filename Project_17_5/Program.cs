// Coordinate Finder - Return (x, y) from direction input.

// Had to do some chatting with ChatGPT to learn how to register arrow-key presses

(int x, int y) position = (0, 0);


while(true)
{
    Console.Clear();
    Console.WriteLine($"Current position: X: {position.x}, Y: {position.y}\n");
    Console.Write("Change position with the arrow keys.");
    position = Move(position);
}


// Local Functions
(int newX, int newY) Move((int x, int y) pos)
{
    ConsoleKeyInfo keyInfo;

    keyInfo = Console.ReadKey(true);

    return keyInfo.Key switch
    {
        ConsoleKey.UpArrow => (pos.x, pos.y + 1),
        ConsoleKey.DownArrow => (pos.x, pos.y - 1),
        ConsoleKey.LeftArrow => (pos.x - 1, pos.y),
        ConsoleKey.RightArrow => (pos.x + 1, pos.y),
    };
}
