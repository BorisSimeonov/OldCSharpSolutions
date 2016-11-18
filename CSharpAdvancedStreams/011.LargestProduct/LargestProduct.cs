using System;

class LargestProduct
{
    static void Main()
    {
        string numbers = Console.ReadLine();
        int maxSum = int.MinValue;
        int currentSum;
        for (int idx = 0; idx <= numbers.Length - 6; idx++)
        {
            currentSum = 1;
            for (int ch = idx; ch < idx + 6; ch++)
            {
                int value = int.Parse(numbers[ch].ToString());
                currentSum *= value;
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }
        Console.WriteLine(maxSum);
    }
}