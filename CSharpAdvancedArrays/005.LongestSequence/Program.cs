//longest increasing sequence of ints (input ex. "2 3 4 1 50 2 3 4 5")
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] intArray = Array.ConvertAll(Regex.Split(Console.ReadLine().Trim(), @"\s+"), i => int.Parse(i));
        int startIdxMax = 0;
        int maxLength = 0;
        int currentLength = 0;
        int prevNum = int.MinValue;
        Console.Clear();
        for (int idx = 0; idx < intArray.Length; idx++)
        {
            if (idx == 0 || prevNum < intArray[idx])
            {
                prevNum = intArray[idx];
                currentLength++;
                Console.Write("{0} ", intArray[idx]);
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    startIdxMax = idx - maxLength;
                }
                prevNum = intArray[idx];
                currentLength = 1;
                Console.Write("\n{0} ", intArray[idx]);
            }
            if (idx == intArray.Length - 1)
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    startIdxMax = idx - (maxLength - 1);
                }
            }
        }
        Console.Write("\nLongest: ");
        for (int idx = startIdxMax; idx < (startIdxMax + maxLength); idx++)
        {
            Console.Write("{0} ", intArray[idx]);
        }
        Console.WriteLine();
    }
}