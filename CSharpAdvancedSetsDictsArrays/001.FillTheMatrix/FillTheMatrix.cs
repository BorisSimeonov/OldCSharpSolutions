using System;

class FillTheMatrix
{
    static void Main(string[] args)
    {
        int matrixSize = GetArraySize();
        int[,] blankMatrix = new int[matrixSize, matrixSize];
        Console.Clear();
        FillAndPrintPatternA(blankMatrix);
        FillAndPrintPatternB(blankMatrix);
    }


    static int GetArraySize()
    {
        int size = 0;
        while (true)
        {
            try
            {
                size = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Invalid Input. Insert A Integer Value!");
            }
        }
        return size;
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                Console.Write(col < matrix.GetLength(0) - 1 ? "{0,4}," : "{0,4}", matrix[row, col]);
            }
            Console.WriteLine("\n");
        }
    }
    static void FillAndPrintPatternA(int[,] matrix)
    {
        Console.WriteLine("Pattern A ({0}x{0})\n", matrix.GetLength(0));
        int numerator = 1;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = numerator;
                numerator++;
            }
        }
        PrintMatrix(matrix);
        Console.WriteLine();
    }
    static void FillAndPrintPatternB(int[,] matrix)
    {
        Console.WriteLine("Pattern B ({0}x{0})\n", matrix.GetLength(0));
        int numerator = 1;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = numerator++;
                }
            }
            else
            {
                for (int row = matrix.GetLength(0)-1; row >= 0; row--)
                {
                    matrix[row, col] = numerator++;
                }
            }
        }
        PrintMatrix(matrix);
        Console.WriteLine();
    }
}