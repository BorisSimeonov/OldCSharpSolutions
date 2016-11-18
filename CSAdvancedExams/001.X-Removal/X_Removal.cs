using System;
using System.Collections.Generic;

class X_Removal
{
    static List<char[]> inputBoard = new List<char[]>();
    static List<char[]> XFreeBoard = new List<char[]>();

    static void Main()
    {
        GetInputChars();
        PrintAll();
    }

    private static void GetInputChars()
    {
        var input = Console.ReadLine();
        while (input != "END")
        {
            inputBoard.Add(input.ToLower().ToCharArray());
            XFreeBoard.Add(input.ToCharArray());
            input = Console.ReadLine();
        }

        for (int row = 0; row < inputBoard.Count - 2; row++)
        {
            int colLimit = Math.Min(inputBoard[row].Length - 2,
                Math.Min(inputBoard[row + 1].Length - 1, inputBoard[row + 2].Length - 2));

            for (int col = 0; col < colLimit; col++)
            {
                char topLeft = inputBoard[row][col];
                char topRight = inputBoard[row][col + 2];
                char middle = inputBoard[row + 1][col + 1];
                char bottomLeft = inputBoard[row + 2][col];
                char bottomRight = inputBoard[row + 2][col + 2];
                if (
                    (topLeft == topRight) &&
                    (topRight == middle) &&
                    (middle == bottomLeft) &&
                    (bottomLeft == bottomRight)
                    )
                {
                    XFreeBoard[row][col] = '\0';
                    XFreeBoard[row][col + 2] = '\0';
                    XFreeBoard[row + 1][col + 1] = '\0';
                    XFreeBoard[row + 2][col] = '\0';
                    XFreeBoard[row + 2][col + 2] = '\0';
                }
            }
        }
    }

    private static void PrintAll()
    {
        foreach (var arr in XFreeBoard)
        {
            foreach (char ch in arr)
            {
                if (ch != '\0')
                {
                    Console.Write(ch);
                }
            }
            Console.WriteLine();
        }
    }

}