using System;

class SequenceInMatrix
{
    static void Main()
    {
        int[] dimensions = new int[2];
        dimensions[0] = int.Parse(Console.ReadLine().Trim());
        dimensions[1] = int.Parse(Console.ReadLine().Trim());
        string[,] matrix = new string[dimensions[0], dimensions[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Clear();
                Console.WriteLine("Give value for [{0},{1}] position: ",
                    row, col);
                matrix[row, col] = Console.ReadLine().Trim();
            }
        }
        Console.Clear();
        PrintMatrix(matrix);
        //Four-way check
        object[] bestMatch = new object[2] { "", 0 };
        bestMatch = HorizontalCheck(matrix, bestMatch);
        bestMatch = VerticalCheck(matrix, bestMatch);
        bestMatch = LeftDiagonalCheck(matrix, bestMatch);
        bestMatch = RightDiagonalCheck(matrix, bestMatch);


        for (int iter = (int)bestMatch[1]; iter > 0; iter--)
        {
            Console.Write(iter == 1 ? "{0}\n" : "{0}, ", bestMatch[0]);
        }
    }


    private static object[] HorizontalCheck(string[,] matrix, object[] bestMatch)
    {
        string previousValue = "";
        string bestSign = "";
        int longestSeq = -1;
        int currentSeq = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == 0)
                {
                    currentSeq = 1;
                    previousValue = matrix[row, col];
                    continue;
                }
                else if (previousValue == matrix[row, col])
                {
                    currentSeq++;
                    continue;
                }
                else
                {
                    if (currentSeq > longestSeq)
                    {
                        longestSeq = currentSeq;
                        currentSeq = 1;
                        bestSign = previousValue;
                        previousValue = matrix[row, col];
                    }
                    else
                    {
                        currentSeq = 1;
                        previousValue = matrix[row, col];
                    }
                }
            }
            if (currentSeq > longestSeq)
            {
                longestSeq = currentSeq;
                bestSign = previousValue;
            }
        }

        if ((int)bestMatch[1] < longestSeq)
        {
            bestMatch[0] = bestSign;
            bestMatch[1] = longestSeq;
        }

        return bestMatch;
    }
    private static object[] VerticalCheck(string[,] matrix, object[] bestMatch)
    {
        string previousValue = "";
        string bestSign = "";
        int longestSeq = -1;
        int currentSeq = 0;

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == 0)
                {
                    currentSeq = 1;
                    previousValue = matrix[row, col];
                    continue;
                }
                else if (previousValue == matrix[row, col])
                {
                    currentSeq++;
                    continue;
                }
                else
                {
                    if (currentSeq > longestSeq)
                    {
                        longestSeq = currentSeq;
                        currentSeq = 1;
                        bestSign = previousValue;
                        previousValue = matrix[row, col];
                    }
                    else
                    {
                        currentSeq = 1;
                        previousValue = matrix[row, col];
                    }
                }
            }
            if (currentSeq > longestSeq)
            {
                longestSeq = currentSeq;
                bestSign = previousValue;
            }
        }

        if ((int)bestMatch[1] < longestSeq)
        {
            bestMatch[0] = bestSign;
            bestMatch[1] = longestSeq;
        }

        return bestMatch;
    }
    private static object[] LeftDiagonalCheck(string[,] matrix, object[] bestMatch)
    {
        string previousValue = "";
        string bestValue = "";
        int longestSeq = -1;
        int currentSeq = -2;

        //start at bottom 3right side
        int maxRow = matrix.GetLength(0);
        int maxCol = matrix.GetLength(1);

        for (int row = maxRow - 1, col = maxCol - 1; row >= 0 && col >= 0;)
        {
            currentSeq = 0;
            previousValue = "";
            for (int innerRow = row, innerCol = col; innerRow >= 0 && innerCol >= 0 &&
                innerRow < matrix.GetLength(0); innerRow++, innerCol--)
            {
                if (previousValue == matrix[innerRow, innerCol])
                {
                    currentSeq++;
                }
                else
                {
                    if (currentSeq > longestSeq)
                    {
                        longestSeq = currentSeq;
                        bestValue = previousValue;
                    }
                    previousValue = matrix[innerRow, innerCol];
                    currentSeq = 1;
                }
            }
            if (currentSeq > longestSeq)
            {
                longestSeq = currentSeq;
                bestValue = previousValue;
            }
            //move to the next block of the frame
            if (row > 0)
            {
                row--;
            }
            else
            {
                col--;
            }
        }
        if ((int)bestMatch[1] < longestSeq)
        {
            bestMatch[1] = longestSeq;
            bestMatch[0] = bestValue;
        }
        return bestMatch;
    }
    private static object[] RightDiagonalCheck(string[,] matrix, object[] bestMatch)
    {
        string previousValue = "";
        string bestValue = "";
        int longestSeq = -1;
        int currentSeq = -2;

        //start at bottom left side
        int startRow = matrix.GetLength(0);
        int maxCol = matrix.GetLength(1);

        for (int row = startRow - 1, col = 0; row >= 0 && col < maxCol;)
        {
            currentSeq = 0;
            previousValue = "";
            for (int innerRow = row, innerCol = col; innerRow >= 0 && innerCol < maxCol &&
                innerRow < matrix.GetLength(0); innerRow++, innerCol++)
            {
                if (previousValue == matrix[innerRow, innerCol])
                {
                    currentSeq++;
                }
                else
                {
                    if (currentSeq > longestSeq)
                    {
                        longestSeq = currentSeq;
                        bestValue = previousValue;
                    }
                    previousValue = matrix[innerRow, innerCol];
                    currentSeq = 1;
                }
            }
            if (currentSeq > longestSeq)
            {
                longestSeq = currentSeq;
                bestValue = previousValue;
            }
            //move to the next block of the frame
            if (row > 0)
            {
                row--;
            }
            else
            {
                col++;
            }
        }
        if ((int)bestMatch[1] < longestSeq)
        {
            bestMatch[1] = longestSeq;
            bestMatch[0] = bestValue;
        }
        return bestMatch;
    }


    static void PrintMatrix(string[,] matrix)
    {
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, 4} ",
                    matrix[row, col]);
            }
            Console.WriteLine("\n");
        }
    }
}