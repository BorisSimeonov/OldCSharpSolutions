//Sort Array of Numbers Using Bubble Sort
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int arrSize = 0;
        bool done = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Enter the size of the array: ");
            done = int.TryParse(Console.ReadLine(), out arrSize);
        } while (!done);

        int[] arrayOfInts = new int[arrSize];
        for (int idx = 0; idx < arrSize; idx++)
        {
            Console.WriteLine("Enter value for arrayOfInts[{0}]: ", idx);
            done = int.TryParse(Console.ReadLine(), out arrayOfInts[idx]);
            if (!done)
            {
                idx--;
                Console.Clear();
                Console.WriteLine("Invalid Input. Input only integers.\n");
            }
        }



        //Bubble sort array

        //Version one
        //int lastIndex = arrayOfInts.Length - 1;
        //int buffer;
        //for (int cicles = 0, start = 0; cicles < arrayOfInts.Length; cicles++)
        //{
        //    while (start < lastIndex)
        //    {
        //        if (arrayOfInts[start] > arrayOfInts[start+1])
        //        {
        //            buffer = arrayOfInts[start];
        //            arrayOfInts[start] = arrayOfInts[start + 1];
        //            arrayOfInts[start + 1] = buffer;
        //        }
        //        start++;
        //    }
        //    start = 0;
        //    lastIndex--;
        //}

        //Version Two

        int temp, skip = 0;
        bool hasChange = true;

        while (hasChange)
        {
            skip++;
            hasChange = false;
            for (int idx = 0; idx < arrayOfInts.Length - skip; idx++)
            {
                if (arrayOfInts[idx] > arrayOfInts[idx + 1])
                {
                    temp = arrayOfInts[idx];
                    arrayOfInts[idx] = arrayOfInts[idx + 1];
                    arrayOfInts[idx + 1] = temp;
                    hasChange = true;
                }
            }
        }

        Console.WriteLine("B-Sorted Asc. Array: [" + string.Join(", ", arrayOfInts) + "]");
    }
}