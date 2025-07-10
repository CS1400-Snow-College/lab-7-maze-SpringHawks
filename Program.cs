// Annette Hawks
// Due 7/9/2025
// Lab 7 Maze

// Maze Rules
string mazeRules = "MAZE RULES:\n" +
    "1. Use the arrow keys to navigate the maze.\n" +
    "2. The walls are hashtags (#).\n" +
    "3. You want to find the asterisk * to win.\n";

Console.WriteLine(mazeRules);

// Keep instructions up long enough for the person to read them
Console.WriteLine("Press any key to load maze...");
Console.ReadKey(true);

Console.Clear();


// Load maze 
string[] mapRows = File.ReadAllLines("map.txt");

// Display Maze
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}

// Start player at top left corner (0,0)
Console.SetCursorPosition(0, 0);
ConsoleKey keyStroke;

bool winner = false;

do
{
    keyStroke = Console.ReadKey(true).Key;

    int cursorTop = Console.CursorTop;
    int cursorLeft = Console.CursorLeft;

    int newCursorTop = cursorTop;
    int newCursorLeft = cursorLeft;

    switch (keyStroke)
    {
        case ConsoleKey.Escape:
            return;

        case ConsoleKey.UpArrow:
            newCursorTop = cursorTop - 1;
            break;

        case ConsoleKey.DownArrow:
            newCursorTop = cursorTop + 1;
            break;

        case ConsoleKey.LeftArrow:
            newCursorLeft = cursorLeft - 1;
            break;

        case ConsoleKey.RightArrow:
            newCursorLeft = cursorLeft + 1;
            break;
    }

    // Stay on the Map 
    if (newCursorTop >= 0 && newCursorTop < mapRows.Length &&
        newCursorLeft >= 0 && newCursorLeft < mapRows[newCursorTop].Length)
    {
        Console.SetCursorPosition(newCursorLeft, newCursorTop);
    }

} while (true);
