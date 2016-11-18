using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();
        while (true)
        {
            string buffer = Console.ReadLine();
            if (buffer == "END")
            {
                break;
            }
            text.AppendLine(buffer);
        }

        string pattern = @"(?:<a)(?:[\s\n_0-9a-zA-Z=""()]*?.*?)" +
        @"(?:href([\s\n]*)?=(?:['""\s\n]*)?)([a-zA-Z:#\/._\-0-9!?=^+]" +
        @"*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\s\na-zA-Z=""()0-9]*.*?)?(?:\>)";
        Match m = Regex.Match(text.ToString(), pattern);
        bool check = true;
        while (m.Success)
        {
            Console.WriteLine(m.Groups[2].Value);
            m = m.NextMatch();
            check = false;
        }

        if (check)
        {
            Console.WriteLine();
        }
    }
}