//You are given a sequence of text lines, holding symbols, 
//small and capital Latin letters.Your task is to remove 
//all "plus shapes" in the text.They may consist of small 
//and capital letters at the same time, or of any symbol.
//Every "plus shape" is 3 by 3 symbols crossing each other 
//on 3 lines.Single "plus shape" can be part of multiple 
//"plus shapes". If new "plus shapes" are formed after the 
//first removal you don't have to remove them.

//ex.input:
//ab** l5
//bBb*555
//absh*5
//ttHHH
//ttth
//END


using System;
using System.Linq;

class PlusRemove
{
    static char[][] lineArray;
    static string[] crossFree;
    static void Main()
    {
        lineArray = GetInputArray();
        crossFree = new string[lineArray.GetLength(0)];
        
        for (int row = 0; row < lineArray.GetLength(0); row++)
        {
            for (int col = 0; col < lineArray[row].Length; col++)
            {
                bool notInCross = true;
                notInCross = notInCross && CheckUpper(row, col);
                notInCross = notInCross && CheckLower(row, col);
                notInCross = notInCross && CheckMiddle(row, col);
                notInCross = notInCross && CheckLeft(row, col);
                notInCross = notInCross && CheckRight(row, col);
                if (notInCross)
                {
                    crossFree[row] += lineArray[row][col];
                }
            }
        }

        PrintAll(crossFree);
    }

    private static bool CheckRight(int row, int col)
    {
        try
        {
            if (
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row][col - 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row][col - 2])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row + 1][col - 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row - 1][col - 1]))
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return true;
        }
    }

    private static bool CheckLeft(int row, int col)
    {
        try
        {
            if (
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row][col + 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row][col + 2])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row + 1][col + 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row - 1][col + 1]))
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return true;
        }
    }

    private static bool CheckMiddle(int row, int col)
    {
        try
        {
            if (
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row - 1][col])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row][col - 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row][col + 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row + 1][col]))
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return true;
        }
    }

    private static bool CheckLower(int row, int col)
    {
        try
        {
            if (
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row - 1][col])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row - 1][col - 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row - 1][col + 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row - 2][col]))
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return true;
        }
    }

    private static bool CheckUpper(int row, int col)
    {
        try
        {
            if (
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row + 1][col])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row + 1][col - 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row + 1][col + 1])) &&
                (char.ToLowerInvariant(lineArray[row][col]) == char.ToLowerInvariant(lineArray[row + 2][col]))
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return true;
        }
    }

    private static char[][] GetInputArray()
    {
        string buffer = "";
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "end")
            {
                break;
            }
            buffer += (input + " ");
        }
        buffer = buffer.Trim();
        string[] stringArray = buffer.Split(' ').ToArray();
        char[][] chArray = new char[stringArray.Length][];
        for (int x = 0; x < stringArray.Length; x++)
        {
            chArray[x] = stringArray[x].ToCharArray();
        }
        return chArray;
    }

    static void PrintAll(string[] printArray)
    {
        for (int x = 0; x < printArray.GetLength(0); x++)
        {
            Console.WriteLine(printArray[x]);
        }
    }
}