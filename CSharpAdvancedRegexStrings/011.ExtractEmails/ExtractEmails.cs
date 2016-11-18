using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string inLine = Console.ReadLine();
        Regex reg = new Regex(@"([a-zA-Z]+[\.[a-zA-Z]*\@[a-z0-9]+[a-z\.]+[a-z]{2,3})");
        Match m = reg.Match(inLine);
        SortedSet<string> extractList = new SortedSet<string>(); //ignoring the duplicate inputs
        while (m.Success)
        {
            extractList.Add(m.Value);
            m = m.NextMatch();
        }
        Console.WriteLine("\nResult count - {0}:\n" + string.Join("\n", extractList), extractList.Count());
    }
}