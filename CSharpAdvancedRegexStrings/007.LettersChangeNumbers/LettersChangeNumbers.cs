using System;
using System.Text.RegularExpressions;

class LettersChangeNumbers
{
    static void Main()
    {
        string[] input = Regex.Split(Console.ReadLine().Trim(), @"\s+");
        Regex reg = new Regex(@"^([a-zA-Z])(\d+)([a-zA-Z])$");
        double sum = 0d;
        double current = 0d;
        for (int idx = 0; idx < input.Length; idx++)
        {      
            Match match = reg.Match(input[idx]);
            while (match.Success)
            {
                char fstChar = char.Parse(match.Groups[1].Value);
                current = double.Parse(match.Groups[2].Value);
                //firstChar
                if (char.IsUpper(fstChar))
                {
                    current /= ((int)fstChar - 64);
                }
                else
                {
                    current *= ((int)fstChar - 96);
                }
                //lastChar
                char sndChar = char.Parse(match.Groups[3].Value);
                if (char.IsUpper(sndChar))
                {
                    current -= ((int)sndChar - 64);
                }
                else
                {
                    current += ((int)sndChar - 96);
                }

                sum += current;
                match = match.NextMatch();
            }
        }
        Console.WriteLine("{0:f2}", sum);
    }
}