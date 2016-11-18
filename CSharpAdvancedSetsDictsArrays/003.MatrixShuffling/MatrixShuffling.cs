//Write a program which reads a string matrix from
//the console and performs certain operations with 
//its elements.User input is provided like in the 
//problem above – first you read the dimensions and 
//then the data.Remember, you are not required to do 
//this step first, you may add this functionality later.  

//Your program should then receive commands in format: 
//"swap x1 y1 x2 y2" where x1, x2, y1, y2 are coordinates 
//in the matrix. In order for a command to be valid, it 
//should start with the "swap" keyword along with four valid 
//coordinates (no more, no less). You should swap the values 
//at the given coordinates(cell[x1, y1] with cell[x2, y2]) 
//and print the matrix at each step(thus you'll be able to 
//check if the operation was performed correctly).

//ex.input: 
//2
//3
//1
//2
//3
//4
//5
//6
//swap 0 0 1 1
//swap 10 9 8 7
//swap 0 1 1 0
//END


using System;
using System.Text.RegularExpressions;

class MatrixShuffling
{
    static void Main()
    {
        int[] dimensions = new int[2];
        dimensions = getDimensions(dimensions);
        string[,] matrix = new string[dimensions[0], dimensions[1]];
        matrix = GetMatrixValues(matrix);
        MakeValueChanges(matrix);

    }

    private static int[] getDimensions(int[] dimensions)
    {
        for (int x = 0; x < 2; x++)
        {
            bool done = int.TryParse(Console.ReadLine().Trim(), out dimensions[x]);
            if (!done)
            {
                x--;
            }
        }
        return dimensions;
    }

    private static string[,] GetMatrixValues(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = Console.ReadLine().Trim();
            }
        }
        return matrix;
    }

    private static void MakeValueChanges(string[,] matrix)
    {
        while (true)
        {
            string[] command;
            command = Regex.Split(Console.ReadLine().Trim(), @"\s+");
            if (command[0].ToLower() == "end")
            {
                break;
            }

            if (command.Length != 5 || command[0].ToLower() != "swap")
            {
                Console.WriteLine("Invalid Input.");
                continue;
            }

            //---------------------------------------------------
            //Main Changer
            int[] intPositions = new int[4]
                {
                    int.Parse(command[1]),
                    int.Parse(command[2]),
                    int.Parse(command[3]),
                    int.Parse(command[4])
                };
            if (
                (intPositions[0] < 0 || intPositions[0] > matrix.GetLength(0)) ||
                (intPositions[1] < 0 || intPositions[1] > matrix.GetLength(1)) ||
                (intPositions[2] < 0 || intPositions[2] > matrix.GetLength(0)) ||
                (intPositions[3] < 0 || intPositions[3] > matrix.GetLength(1))
                )
            {
                Console.WriteLine("Invalid Input.");
            }
            else
            {
                string buffer = matrix[intPositions[0], intPositions[1]];
                matrix[intPositions[0], intPositions[1]] = matrix[intPositions[2], intPositions[3]];
                matrix[intPositions[2], intPositions[3]] = buffer;
                PrintMatrix(matrix);
            }
        }
    }

    private static void PrintMatrix(string[,] mtrx)
    {
        for (int row = 0; row < mtrx.GetLength(0); row++)
        {
            for (int col = 0; col < mtrx.GetLength(1); col++)
            {
                Console.Write("{0,4} ", mtrx[row, col]);
            }
            Console.WriteLine("\n");
        }
        return;
    }
}