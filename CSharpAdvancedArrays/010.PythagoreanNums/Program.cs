//George likes math.Recently he discovered an interesting property 
//of the Pythagorean Theorem: there are infinite number of triplets 
//of integers a, b and c(a ≤ b), such that a2 + b2 = c2.Write a 
//program to help George find all such triplets(called Pythagorean
//numbers) among a set of integer numbers. (with duplicated values for the three!!!)

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int cnt = int.Parse(Console.ReadLine());
        List<int> numList = new List<int>();
        bool hasResult = false;
        for (int x = 0; x < cnt; x++)
        {
            numList.Add(int.Parse(Console.ReadLine().Trim()));
        }

        if (numList.Count >= 3)
        {
            for (int fst = 0; fst < cnt; fst++)
            {
                for (int snd = 0; snd < cnt; snd++)
                {
                    if (numList[fst] > numList[snd] /*|| fst == snd*/) { continue; };
                    for (int trd = 0; trd < cnt; trd++)
                    {
                        //if (trd == snd || trd == fst) { continue; };
                        //--------------------------------------------------------
                        if (Math.Pow(numList[fst], 2) + Math.Pow(numList[snd], 2) ==
                            Math.Pow(numList[trd], 2))
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}",
                                numList[fst], numList[snd], numList[trd]);
                            hasResult = true;
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