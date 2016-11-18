using System;
using System.Collections.Generic;
using System.Linq;

class BitwiseOperators
{
    static List<int> newNumbers = new List<int>();
    static void Main()
    {

        int numCount = int.Parse(Console.ReadLine());
        for (int iter = 0; iter < numCount; iter++ )
        {
            TransformBits(int.Parse(Console.ReadLine()));
        }

        newNumbers.ForEach(number => Console.WriteLine(number));
    }

    private static void TransformBits(int number)
    {
        char[] bitNumber = Convert.ToString(number, 2).ToCharArray();
        int reversed = Convert.ToInt32(
            string.Join("", bitNumber.Reverse()), 2);

        int inverted = 
            Convert.ToInt32(
                string.Join("", bitNumber
                        .Select(bit =>
                        {
                            char newBit = '0';
                            if (bit == '0')
                            {
                                newBit = '1';
                            }
                            return newBit;
                        })
                    )
            , 2);
        newNumbers.Add((number^inverted)&reversed);
    }
}