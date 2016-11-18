using System;
using System.Collections.Generic;
using System.Linq;

class Palindromes
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new char[]
        { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        HashSet<string> palindromes = new HashSet<string>();
        palindromes = PalindromeCheck(input, palindromes);
        Console.WriteLine(palindromes.Count() >= 1 ?
            string.Join(", ", palindromes.ToArray().OrderBy(p => p)) :
            "No results found.");
    }

    private static HashSet<string> PalindromeCheck(string[] input, HashSet<string> container)
    {
        foreach (string x in input)
        {
            bool isPal = true;
            for (int start = 0, end = x.Length - 1; start < x.Length / 2; start++, end--)
            {
                if (x[start] != x[end])
                {
                    isPal = false;
                    break;
                }
            }
            if (isPal)
            {
                container.Add(x);
            }
        };

        return container;
    }
}