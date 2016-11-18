using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ToTheStars
{
    static Dictionary<string, double[]> starSystems = new Dictionary<string, double[]>();
    static double[] shipPosition = new double[2];
    static int moves = 0;
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = 
            System.Globalization.CultureInfo.InvariantCulture;
        for (int x = 0; x < 3; x++)
        {
            string[] input = Regex.Split(Console.ReadLine().Trim(), @"\s+");
            starSystems[input[0]] = new double[2] 
                { double.Parse(input[1]), double.Parse(input[2]) };
        }
        shipPosition = Array.ConvertAll(Regex.Split(Console.ReadLine().Trim(),
            @"\s+"), i => double.Parse(i));
        moves = int.Parse(Console.ReadLine().Trim());
        for (int i = -1; i < moves; i++)
        {
            CheckPosition();
            shipPosition[1] += 1;
        }
    }

    static void CheckPosition()
    {
        bool inSpace = true;
        foreach (var x in starSystems)
        {
            if (
                (shipPosition[0] <= x.Value[0]+1 && shipPosition[0] >= x.Value[0] - 1) &&
                (shipPosition[1] <= x.Value[1] + 1 && shipPosition[1] >= x.Value[1] - 1)
                )
            {
                inSpace = false;
                Console.WriteLine(x.Key.ToLower());
                return;
            }
        }
        if (inSpace)
        {
            Console.WriteLine("space");
            return;
        }
    }
}