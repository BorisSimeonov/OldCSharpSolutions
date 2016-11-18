using System;

class Program
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;
        int[] nums = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azit" };
        DateTime[] dates =
            { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6),
              new DateTime(2014, 1, 1)};

        SortArray(nums);
        SortArray(strings);
        SortArray(dates);

    }

    static void SortArray <T>(T[] inArray) where T : IComparable
    {
        Console.WriteLine(typeof(T));
        for (int fst = 0; fst < inArray.Length; fst++)
        {
            for (int check = fst + 1; check < inArray.Length; check++)
            {
                if (!inArray[fst].Equals(inArray[check]))
                {
                    if (inArray[fst].CompareTo(inArray[check]) > 0)
                    {
                        var buffer = inArray[fst];
                        inArray[fst] = inArray[check];
                        inArray[check] = buffer;
                    }
                }
            }
        }

        for (int idx = 0; idx < inArray.Length; idx++)
        {
            Console.Write(idx != inArray.Length - 1 ? "{0}, " : "{0}\n\n", inArray[idx]);
        }
    }
}