//Write a program that reads a string from the console and 
//replaces all series of consecutive identical letters with 
//a single one.


using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        Regex reg = new Regex(@"([a-zA-Z ])\1+");
        Match m = reg.Match(input);
        while (m.Success)
        {
            input = Regex.Replace(input, m.Value, m.Value[0].ToString());
            m = m.NextMatch();
        }
        Console.WriteLine(input);
    }
}