using System;

class LabyrinthDash
{
    static int rowPos = 0;
    static int colPos = 0;
    static int moveCounter = 0;
    static int lives = 3;
    static char[][] lab;

    static void Main()
    {
        int arrSize = int.Parse(Console.ReadLine());
        lab = new char[arrSize][];
        for (int row = 0; row < arrSize; row++)
        {
            lab[row] = Console.ReadLine().ToCharArray();
        }
        string moves = Console.ReadLine();
        CheckMove(moves);
        Console.WriteLine("Total moves made: {0}", moveCounter);
    }

    private static void CheckMove(string movesString)
    {
        int nextRow, nextCol;
        for (int idx = 0; idx < movesString.Length; idx++)
        {
            nextRow = rowPos;
            nextCol = colPos;
            switch (movesString[idx])
            {
                case '>':
                    nextCol++;
                    break;
                case '<':
                    nextCol--;
                    break;
                case '^':
                    nextRow--;
                    break;
                case 'v':
                    nextRow++;
                    break;
            }
            if (nextRow < 0 || nextRow >= lab.Length ||
                nextCol < 0 || nextCol >= lab[nextRow].Length ||
                lab[nextRow][nextCol] == ' ')
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                moveCounter++;
                break;
            }
            else
            {
                char landSymbol = lab[nextRow][nextCol];
                switch (landSymbol)
                {
                    case '$':
                        moveCounter++;
                        lives++;
                        Console.WriteLine("Awesome! Lives left: {0}", lives);
                        lab[nextRow][nextCol] = '.';
                        rowPos = nextRow;
                        colPos = nextCol;
                        break;
                    case '.':
                        moveCounter++;
                        Console.WriteLine("Made a move!");
                        rowPos = nextRow;
                        colPos = nextCol;
                        break;
                    case '|':
                    case '_':
                        Console.WriteLine("Bumped a wall.");
                        break;
                    case '@':
                    case '#':
                    case '*':
                        lives--;
                        moveCounter++;
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        rowPos = nextRow;
                        colPos = nextCol;
                        if (lives == 0)
                        {
                            Console.WriteLine("No lives left! Game Over!");
                            idx = movesString.Length;
                        }
                        break;
                    default:
                        Console.WriteLine("Made a move!");
                        moveCounter++;
                        break;
                }
            }
        }
    }
}