//Write a method that returns the index of the first element 
//in array that is larger than its neighbours, or -1 if there's
//no such element. 
using System;
using System.Text.RegularExpressions;

class FirstBiggerThanNeighbours
{
    static void Main()
    {
        try
        {
            int[] x = Array.ConvertAll(Regex.Split(Console.ReadLine().Trim(),
                @"\s+"), i => int.Parse(i));
            Console.WriteLine(ReturnFirstBiggerNumIndex(x));
        }
        catch
        {
            Console.WriteLine("Conversion Error!");
        }
    }
    static int ReturnFirstBiggerNumIndex(int[] numArr)
    {
        int index = -1;
        for (int idx = 0; idx < numArr.Length; idx++)
        {
            if ((idx > 0 && idx < numArr.Length - 1) &&
                (numArr[idx] > numArr[idx - 1] &&
                numArr[idx] > numArr[idx + 1]))
            {
                index = idx;
                break;
            }
            else if (idx == 0 && (numArr[idx] > numArr[idx + 1]))
            {
                index = idx;
                break;
            }
            else if(idx == numArr.Length - 1 && 
                (numArr[idx] > numArr[idx - 1]))
            {
                index = idx;
                break;
            }
        }
        return index;
    }
}