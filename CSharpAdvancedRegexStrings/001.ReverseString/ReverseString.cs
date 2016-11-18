using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        string str = Console.ReadLine();
        if (str.Length > 1)
        {
            str = new string(str.ToCharArray().Reverse().ToArray());
            Console.WriteLine(str);
        }
        else
        {
            Console.WriteLine("Too Short.");
        }
    }
}