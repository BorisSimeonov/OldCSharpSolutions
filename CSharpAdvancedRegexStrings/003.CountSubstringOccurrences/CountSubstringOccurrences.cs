//Write a program to find how many times a given
//string appears in a given text as substring.The
//text is given at the first input line.The search
//string is given at the second input line. The 
//output is an integer number.Please ignore the 
//character casing.Overlapping between occurrences 
//is allowed.

using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine();
        string match = Console.ReadLine();
        int mCount = 0;
        for (int x = 0; x < input.Length; x++)
        {
            int index = input.ToLower().IndexOf(match, x);
            if (index != -1)
            {
                mCount++;
                x = index;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(mCount);
    }
}