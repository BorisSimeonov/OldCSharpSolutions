//Write methods to calculate the minimum, maximum, average, 
//sum and product of a given set of numbers.Overload the methods 
//to work with numbers of type double and decimal.
using System;
using System.Text.RegularExpressions;

class NumberCalculations
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = 
            System.Globalization.CultureInfo.InvariantCulture;
        try
        {
            decimal[] numbers = Array.ConvertAll(Regex.Split(Console.ReadLine().Trim(),
                @"\s+"), i => decimal.Parse(i));
            NumberCalculation(numbers);
        }
        catch
        {
            Console.WriteLine("Conversion Error!");
        }
    }

    static void NumberCalculation(decimal[] nums)
    {
        Console.Clear();
        decimal minValue = decimal.MaxValue;
        decimal maxValue = decimal.MinValue;
        decimal sum = 0;

        foreach (decimal x in nums)
        {
            minValue = Math.Min(minValue, x);
            maxValue = Math.Max(maxValue, x);
            sum += x;
        }

        Console.WriteLine("Minimal Value: {0}\nMaximal Value: {1}\n"+
            "Average : {2}\nSum : {3}", minValue, maxValue, (sum/nums.Length), sum);
    }
        
}