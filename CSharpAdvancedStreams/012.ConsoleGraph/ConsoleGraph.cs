//C# Basics November 2014 Lab - Console graphics

using System;

class ConsoleGraph
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}\n{0}", new string('*', n * 2));
        for (int x = 1; x < n; x++)
        {
            Console.WriteLine("{0}{1}{0}", new string('*', ((n * 2) - (n - 1))/2),
                new string(' ', n - 1));
        }
        Console.WriteLine("{0}\n{0}", new string('~', n * 2));
    }
}