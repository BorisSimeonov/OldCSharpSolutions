//Write a program that reads a keyword and some text from the 
//console and prints all sentences from the text, containing 
//that word.A sentence is any sequence of words ending with 
//'.', '!' or '?'.


using System;
using System.Text.RegularExpressions;

class SentenceExtractor
{
    static void Main()
    {
        string keyWord = Console.ReadLine().Trim();
        string fullText = Console.ReadLine();
        Regex reg = new Regex(@"([A-Z][\w\d\,\s\-]*?\s"+ keyWord +@"\s.*?[\.|\!|\?])");
        var sentences = reg.Matches(fullText);
        Console.WriteLine();
        foreach (var x in sentences)
        {
            Console.WriteLine(x);
        }
    }
}