//Sort array of numbers --- Valid input!
using System;
using System.Linq;
using System.Text.RegularExpressions;

class SortArrayOfNums
{
    static void Main(string[] args)
    {
        int[] numArray = Array.ConvertAll(Regex.Split(Console.ReadLine().Trim(), @"\s+"), p => int.Parse(p));
        Array.Sort(numArray, (a, b) => a.CompareTo(b));
        numArray.ToList().ForEach(x => Console.Write("{0} ", x));
    }
}