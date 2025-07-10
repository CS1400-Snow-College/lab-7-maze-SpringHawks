// Annette Hawks
// Due 7/9/2025
// Lab 7 Maze
 {
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

            bool winner = TryMove(newCursorTop, newCursorLeft, mapRows);

            if (winner)
            {
                Console.Clear();
                Console.WriteLine("You win!");
                break;
            }

        } while (true);
    }

    static bool TryMove(int proposedTop, int proposedLeft, string[] mazeRows)
    {
        if (proposedTop < 0 || proposedTop >= mazeRows.Length)
            return false;

        if (proposedLeft < 0 || proposedLeft >= mazeRows[proposedTop].Length)
            return false;

        char targetCell = mazeRows[proposedTop][proposedLeft];

        if (targetCell == '#')
            return false;

        if (targetCell == '*')
            return true;

        Console.SetCursorPosition(proposedLeft, proposedTop);
        return false;
    }
