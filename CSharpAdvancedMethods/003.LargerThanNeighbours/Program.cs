using System;
using System.Text.RegularExpressions;

class LargerThanNeighbours
{
    static void Main(string[] args)
    {
        int[] intNumbers = Array.ConvertAll(Regex.Split(Console.ReadLine().Trim(),
            @"\s+"), e => int.Parse(e));
        LargerThanNeighbourNums(intNumbers);
    }
    static void LargerThanNeighbourNums(int[] numArray)
    {
        for (int x = 0; x < numArray.Length; x++)
        {
            if (x > 0 && x < numArray.Length - 1)
            {
                Console.WriteLine(numArray[x] > numArray[x - 1] &&
                numArray[x] > numArray[x + 1]);
            }
            else if (x == 0)
            {
                Console.WriteLine(numArray[x] > numArray[x + 1]);
            }
            else
            {
                Console.WriteLine(numArray[x] > numArray[x - 1]);
            }
        }
    }
}