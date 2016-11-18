using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int count;
        int.TryParse(Console.ReadLine(), out count);
        string[] array = Regex.Split(Console.ReadLine().Trim(), @"\s+").Distinct().ToArray();
        count = array.Length;
        bool hasResult = false;

        if (array.Length > 4)
        {
            string[] values = new string[2];

            for (int fst = 0; fst < count; fst++)
            {
                for (int snd = 0; snd < count; snd++)
                {
                    if (snd == fst) { continue; };
                    values[0] = (array[fst] + array[snd]);
                    for (int trd = 0; trd < count; trd++)
                    {
                        if (trd == fst || trd == snd) { continue; };
                        for (int frt = 0; frt < count; frt++)
                        {
                            if (frt == fst || frt == snd || frt == trd) { continue; };
                            values[1] = (array[trd] + array[frt]);
                            //-----------------------------------------------------
                            if (values[0].Equals(values[1]))
                            {
                                Console.WriteLine("{0}|{1}=={2}|{3}",
                                    array[fst], array[snd], array[trd], array[frt]);
                                hasResult = true;
                            }
                        }
                    }
                }
            }
        }

        if (!hasResult)
        {
            Console.WriteLine("No");
        }
    }
}