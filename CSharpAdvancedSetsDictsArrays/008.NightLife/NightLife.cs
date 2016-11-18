using System;
using System.Collections.Generic;

class NightLife
{
    static Dictionary<string, Dictionary<string, HashSet<string>>> nightInfo =
        new Dictionary<string, Dictionary<string, HashSet<string>>>();

    static void Main()
    {
        AddInfo();
        PrintAll();
    }

    static void AddInfo()
    {
        while (true)
        {
            string input = Console.ReadLine().Trim();
            if (input.ToLower() == "end")
            {
                return;
            }
            string[] values = input.Split(';');
            if (!nightInfo.ContainsKey(values[0]))
            {
                Dictionary<string, HashSet<string>> buffer =
                    new Dictionary<string, HashSet<string>>();
                buffer[values[1]] = new HashSet<string> { values[2] };
                nightInfo[values[0]] = buffer;
            }
            else
            {
                if (!nightInfo[values[0]].ContainsKey(values[1]))
                {
                    nightInfo[values[0]].Add(values[1], new HashSet<string>
                    { values[2] });
                }
                else if (nightInfo[values[0]].ContainsKey(values[1]) &&
                    !nightInfo[values[0]][values[1]].Contains(values[2]))
                {
                    nightInfo[values[0]][values[1]].Add(values[2]);
                }
            }
        }
    }

    static void PrintAll()
    {
        Console.Clear();
        foreach (var city in nightInfo)
        {
            Console.WriteLine("{0}", city.Key);
            foreach (var venue in city.Value)
            {
                Console.WriteLine("->{0}: {1}", venue.Key, string.Join(", ", venue.Value));
            }
        }
    }
}