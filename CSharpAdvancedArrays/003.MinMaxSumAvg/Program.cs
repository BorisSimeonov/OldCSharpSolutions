using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        double[] input = Array.ConvertAll(Regex.Split(Console.ReadLine().Trim(), @"\s+"), p => double.Parse(p));
        List<double>[] numbers = new List<double>[2];
        List<double> floating = new List<double>();
        List<double> nonfloating = new List<double>();

        foreach (double x in input)
        {
            if (Math.Round(x) == x)
            {
                nonfloating.Add(x);
                continue;
            }
            floating.Add(x);
        }
        Console.Clear();
        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:0.00}\n",
            String.Join(", ", floating), floating.Min(), floating.Max(),
            floating.Sum(), floating.Average());

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:0.00}",
            String.Join(", ", nonfloating), nonfloating.Min(), nonfloating.Max(),
            nonfloating.Sum(), nonfloating.Average());
    }
}