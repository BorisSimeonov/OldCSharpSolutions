//Sequences of Equal Strings separated by spaces only (ex."hi yes yes yes bye")
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> inputArr = Regex.Split(Console.ReadLine().Trim(), @"\s+").ToList();
        int count = 0;
        string result;
        string item = "";

        while (inputArr.Count() > 0)
        {
            count = inputArr.Count(p => p == inputArr[0]);
            item = inputArr[0];
            result = "";
            for (int iter = 0; iter < count; iter++)
            {
                inputArr.Remove(item);
                result += (" " + item);
            }
            Console.WriteLine(result.Trim());
        }
    }
}