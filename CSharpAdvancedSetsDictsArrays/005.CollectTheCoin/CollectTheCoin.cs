using System;

class CollectTheCoin
{
    static char[][] jBoard = new char[4][];
    static int[] currentPos = { 0, 0 };
    static char[] userCommands;
    static int wallHits = 0, coins = 0;

    static void Main()
    {

        for (int iter = 0; iter < 4; iter++)
        {
            jBoard[iter] = Console.ReadLine().Trim().ToCharArray();
        }
        userCommands = Console.ReadLine().Trim().ToCharArray();
        int index = 0;
        while (index < userCommands.Length)
        {
            newPosition(index);
            index++;
        }
        Console.Clear();
        Console.WriteLine("Coins collected: {0}\n\nWalls hit: {1}",
            coins, wallHits);
    }

    static void newPosition(int charIdx)
    {
        int[] corrector = new int[2];
        switch (userCommands[charIdx])
        {
            case 'V':
                corrector = new int[] { 1, 0 };
                break;
            case '^':
                corrector = new int[] { -1, 0 };
                break;
            case '>':
                corrector = new int[] { 0, 1 };
                break;
            case '<':
                corrector = new int[] { 0, -1 };
                break;
        }
        bool hasMove = true;
        corrector[0] += currentPos[0];
        corrector[1] += currentPos[1];
        hasMove = hasMove && ((corrector[0] < 4 && corrector[0] >= 0) &&
            (corrector[1] >= 0 && corrector[1] < jBoard[corrector[0]].Length));
        if (hasMove)
        {
            currentPos = corrector;
            if (jBoard[currentPos[0]][currentPos[1]] == '$')
            {
                coins++;
            }
        }
        else
        {
            wallHits++;
        }
    }
}