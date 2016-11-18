using System;
using System.Collections.Generic;
using System.Linq;

class CountSymbols
{
    static void Main()
    {
        char[] allChars = Console.ReadLine().Trim().ToCharArray();
        SortedDictionary<char, int> charCount = new SortedDictionary<char, int>();
        foreach (char ch in allChars)
        {
            if (charCount.ContainsKey(ch))
            {
                charCount[ch] += 1;
            }
            else
            {
                charCount.Add(ch, 1);
            }
        }

        foreach (KeyValuePair<char, int> pair in charCount)
        {
            Console.WriteLine("{0}: {1} time/s",
                pair.Key, pair.Value);
        }

        //order the result by value count
        Console.WriteLine("\nSorted items by char ASC and frequency DESC:");
        var sorted = charCount.OrderBy(x => x.Key).OrderBy(x => -x.Value).ToList();
        sorted.ForEach(item => Console.WriteLine("{0}: {1}time/s", item.Key, item.Value));
    }
}