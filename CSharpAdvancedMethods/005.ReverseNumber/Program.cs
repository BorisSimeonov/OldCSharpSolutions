//Write a method that reverses the digits of a given floating-point number.
using System;

class ReverseNumber
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;

        try
        {
            double number = double.Parse(Console.ReadLine().Trim());
            ReverseDoubleNumber(number);
        }
        catch
        {
            Console.WriteLine("Input error.");
        }
    }
    static void ReverseDoubleNumber(double num)
    {
        string buffer = num.ToString();
        for (int x = buffer.Length - 1; x >= 0 ; x--)
        {
            if (x == 1 && 
                (buffer[1] == '.' && buffer[0] == '0'))
            {
                break;
            }
            Console.Write(buffer[x]);
        }
        Console.WriteLine();
    }
}