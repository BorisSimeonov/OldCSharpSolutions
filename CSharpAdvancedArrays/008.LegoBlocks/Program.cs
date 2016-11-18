//You are given two jagged arrays.Each array represents a 
//Lego block containing integers.Your task is first to reverse
//the second jagged array and then check if it would fit
//perfectly in the first jagged array.
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _008.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            List<List<string>> list = new List<List<string>>();
            List<string> buffer = new List<string>();
            int.TryParse(Console.ReadLine(), out count);
            int sumOfAll = 0;
            int baseSum = 0;
            int checker = 0;
            bool areEqual = true;

            for (int x = 0; x < count * 2; x++)
            {
                if (x < count)
                {
                    list.Add(Regex.Split(Console.ReadLine().Trim(), @"\s+").ToList());
                }
                else
                {
                    checker = 0;
                    list[x - count].AddRange(Regex.Split(Console.ReadLine().Trim(), @"\s+").Reverse());
                    list[x - count].ForEach(p => checker++);
                    sumOfAll += checker;
                    if (x - count == 0)
                    {
                        baseSum = sumOfAll;
                    }
                    else
                    {
                        if (checker != baseSum)
                        {
                            areEqual = false;
                        }
                    }
                }
            }
            if (areEqual)
            {
                for (int x = 0; x < list.Count; x++)
                {
                    Console.WriteLine("[{0}]", string.Join(",", list[x]));
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}", sumOfAll);
            }
        }
    }
}