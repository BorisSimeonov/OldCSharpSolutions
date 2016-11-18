using System;
using System.Linq;
using System.Text.RegularExpressions;

class MaximalSubmatrixSum
{
    static void Main()
    {
        int[] size = new int[2];
        int[] buffer = getArrayDimensions();
        if (buffer.Length < size.Length)
        {
            Console.WriteLine("Invalid Input. Two integers needed.");
        }
        else
        {
            for (int idx = 0; idx < buffer.Length && idx < 2; idx++)
            {
                size[idx] = buffer[idx];
            }
            int[,] blankMatrix = new int[size[0], size[1]];
            if (blankMatrix.GetLength(0) < 3 ||
            blankMatrix.GetLength(1) < 3)
            {
                Console.WriteLine("Matrix is too small for the operation!");
            }
            else
            {
                blankMatrix = InsertValues(blankMatrix, size[0]);
                PrintMaxSubmatrixSum(blankMatrix);
            }
            Console.WriteLine("End");
        }

    }

    static int[] getArrayDimensions()
    {
        int[] dimensions;
        while (true)
        {
            try
            {
                dimensions = Array.ConvertAll(Console.ReadLine().Trim().Split(' '),
                    p => int.Parse(p));
                break;
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid Input! Still in cicle.");
                continue;
            }
        }

        return dimensions;
    }
    static int[,] InsertValues(int[,] matrix, int colSize)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] lineBuffer = Regex.Split(Console.ReadLine().Trim(),
            @"\s+").Select(p => int.Parse(p)).ToArray();
            if (lineBuffer.Length == matrix.GetLength(1))
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = lineBuffer[col];
                }
            }
            else
            {
                row--;
            }
        }
        return matrix;
    }
    private static void PrintMaxSubmatrixSum(int[,] matrix)
    {
        int bufferSum = 0;
        int maxSum = int.MinValue;
        int[] maxStartIndex = { 0, 0 };

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                bufferSum =
                    matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (maxSum < bufferSum)
                {
                    maxSum = bufferSum;
                    maxStartIndex = new int[2] { row, col };
                }
            }
        }
        Console.WriteLine("\n\nSum: {0}\n", maxSum);
        //Print max-sum submatrix
        for (int subRow = maxStartIndex[0]; subRow < maxStartIndex[0] + 3; subRow++)
        {
            for (int subCol = maxStartIndex[1]; subCol < maxStartIndex[1] + 3; subCol++)
            {
                Console.Write("{0,4}", matrix[subRow, subCol]);
            }
            Console.WriteLine("\n");
        }
    }
}