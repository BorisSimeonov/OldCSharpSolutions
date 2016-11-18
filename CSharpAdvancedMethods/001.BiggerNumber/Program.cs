using System;

class BiggerNumber
{
    static void Main()
    {
        int numOne = 0, numTwo = 0, larger;
        bool allIntegers = true;
        allIntegers = allIntegers && int.TryParse(Console.ReadLine(), out numOne);
        allIntegers = allIntegers && int.TryParse(Console.ReadLine(), out numTwo);

        if (allIntegers)
        {
            larger = GetBiggest(numOne, numTwo);
            Console.WriteLine("The bigger number from {0} and {1} is {2}",
                numOne, numTwo, larger);
        }
        else
        {
            Console.WriteLine("WrongInput");
        }
    }

    static int GetBiggest(int x, int y)
    {
        return Math.Max(x, y);
    }
}