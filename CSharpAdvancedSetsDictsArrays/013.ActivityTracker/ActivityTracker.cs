using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ActivityTracker
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        SortedDictionary<int,SortedDictionary<string, double>> people =
            new SortedDictionary<int,SortedDictionary<string, double>>();

        int lineCount = int.Parse(Console.ReadLine());
        for (int iter = 0; iter < lineCount; iter++)
        {
            string[] inLine = Regex.Split(Console.ReadLine(), @"\s+");
            string[] date = inLine[0].Split('/');
            int month = int.Parse(date[1]);

            if (!people.ContainsKey(month))
            {
               SortedDictionary<string, double> buffer =
                    new SortedDictionary<string, double>();
                buffer[inLine[1]] = int.Parse(inLine[2]);
                people[month] = buffer;
            }
            else
            {
                if (!people[month].ContainsKey(inLine[1]))
                {
                    people[month].Add(inLine[1], int.Parse(inLine[2]));
                }
                else
                {
                    people[month][inLine[1]] = people[month][inLine[1]] +
                        int.Parse(inLine[2]);
                }
            }
        }

        foreach (var mainKey in people)
        {
            //For use with Dictionary insetad SortedDict as value
            //List<KeyValuePair<string, double>> myList = mainKey.Value.ToList(); 
            //myList = myList.OrderByDescending(p => p.Key).ToList();
            //myList = myList.OrderBy(p => -p.Value).ToList();
            string result = mainKey.Key + ":";
            foreach (var x in mainKey.Value)
            {
                result += string.Format(" {0}({1}),", x.Key, x.Value);
            }
            result = result.Substring(0, result.Length - 1);
            Console.WriteLine(result);
        }
    }
}