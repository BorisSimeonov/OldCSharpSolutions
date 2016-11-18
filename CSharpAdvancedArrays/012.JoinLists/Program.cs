using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        List<string> namesList = new List<string>
        {
            "Ivan",
            "Iliq",
            "Qsen",
            "Gosho",
            "Ivo",
            "Pesho",
        };

        Console.WriteLine(namesList.Count(i => Regex.IsMatch(i, @"I[a-zA-Z]+")));
    }
}