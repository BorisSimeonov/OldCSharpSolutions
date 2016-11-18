using System;

class Disk
{
    static void Main()
    {
        int size = 0, radius = 0;
        int.TryParse(Console.ReadLine(), out size);
        int.TryParse(Console.ReadLine(), out radius);
        int powerRadius = (int)Math.Pow(radius, 2);
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (
                    (int)Math.Pow(Math.Abs(row - (size/2)), 2) +
                    (int)Math.Pow(Math.Abs(col - (size/2)), 2) 
                    <= 
                    powerRadius)
                {
                    Console.Write("*");
                    continue;
                }
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}