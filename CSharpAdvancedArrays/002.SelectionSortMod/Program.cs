//Sort integer input with Alg.
using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll((Console.ReadLine().Trim().Split(' ')), p => int.Parse(p));

        for (int fst = 0; fst < input.Length; fst++)
        {
            for (int check = fst + 1; check < input.Length; check++)
            {
                if (input[fst] > input[check])
                {
                    input[check] += input[fst];
                    input[fst] = input[check] - input[fst];
                    input[check] -= input[fst];
                }
            }
        }
        input.ToList().ForEach(i => Console.Write("{0} ", i));
    }
}