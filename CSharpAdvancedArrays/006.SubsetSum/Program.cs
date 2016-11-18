using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _006.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            int.TryParse(Console.ReadLine(), out number);
            int[] intArray = Regex.Split(Console.ReadLine(), @"\s+").Select(int.Parse).Distinct().ToArray();
            bool hasMatchingSubs = false;
            int combos = (int)Math.Pow(2, intArray.Length);

            for (int mask = 1; mask < combos; mask++)
            {
                int sum = 0;
                List<int> list = new List<int>();
                for (int idx = 0; idx < intArray.Length; idx++)
                {
                    if ((mask >> idx & 1) == 1)
                    {
                        sum += intArray[(intArray.Length - 1) - idx];
                        list.Add(intArray[(intArray.Length - 1) - idx]);
                    }
                }

                if (sum == number)
                {
                    Console.WriteLine("{0} = {1}", string.Join(" + ", list), number);
                    hasMatchingSubs = true;
                }
            }

            if (!hasMatchingSubs)
            {
                Console.WriteLine("No matching subsets.");
            }
        }
    }
}