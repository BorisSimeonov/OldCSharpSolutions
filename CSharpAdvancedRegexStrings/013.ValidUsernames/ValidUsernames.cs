using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ValidUsernames
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex reg = new Regex(@"^([a-zA-Z][a-zA-Z_0-9]{2,24})$");
        List<string> uNames = Regex.Split(input, @"[^\w]").ToList();
        for (int fst = 0; fst < uNames.Count; fst++)
        {
            var x = reg.Match(uNames[fst]);
            if (!x.Success)
            {
                uNames.RemoveAt(fst);
                fst--;
            }
        }
        getBest(uNames);
    }

    private static void getBest(List<string> uNames)
    {
        int maxSum = 0, currentSum;
        int fstMaxIdx = 0;
        for (int fst = 0; fst < uNames.Count - 1; fst++)
        {
            currentSum = uNames[fst].Length + uNames[fst+1].Length;
            if (maxSum < currentSum)
            {
                maxSum = currentSum;
                fstMaxIdx = fst;
            }
        }
        Console.WriteLine("{0}\n{1}",uNames[fstMaxIdx], uNames[fstMaxIdx+1]);
    }
}