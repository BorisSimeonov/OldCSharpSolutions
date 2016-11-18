using System;
using System.Security;

class TextGravity
{
    static int size;
    static string text;
    static char[,] matrix;

    static void Main()
    {
        PopulateMatrix();
        GravityDrop();
        PrintMatrix();
    }

    private static void PrintMatrix()
    {
        Console.Write("<table>");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < size; col++)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(matrix[row, col].ToString()));
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }

    private static void GravityDrop()
    {
        bool hasMoved;
        while (true)
        {
            hasMoved = false;
            for (int col = 0; col < size; col++)
            {
                for (int row = matrix.GetLength(0) - 1; row > 0; row--)
                {
                    if (
                        (matrix[row, col] == ' ' || matrix[row, col] == '\0') &&
                        (matrix[row - 1, col] != ' ' && matrix[row - 1, col] != '\0')
                        )
                    {
                        matrix[row, col] = matrix[row - 1, col];
                        matrix[row - 1, col] = ' ';
                        hasMoved = true;
                    }
                }
            }
            if (!hasMoved)
            {
                break;
            }
        }
    }

    private static void PopulateMatrix()
    {
        size = int.Parse(Console.ReadLine());
        text = Console.ReadLine();
        int rowSize = text.Length / size;
        if (text.Length % size > 0)
        {
            rowSize++;
        }
        matrix = new char[rowSize, size];


        for (int row = 0, idx = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (idx < text.Length)
                {
                    matrix[row, col] = text[idx];
                    idx++;
                    continue;
                }
                matrix[row, col] = ' ';
            }
        }
    }
}