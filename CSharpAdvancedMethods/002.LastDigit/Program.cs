using System;

class LastDigit
{
    static void Main()
    {
        string input = "";
        while (input != "end")
        {
            input = Console.ReadLine().ToLower();
            int n;
            bool isNumeric = int.TryParse(input, out n);

            if (isNumeric)
            {
                Console.WriteLine(GetLastDigitAsWord(n));
            }
            else
            {
                Console.WriteLine("Invalid Input. ({0})", input);
                input = "end";
            }
        }
    }
    static string GetLastDigitAsWord(int num)
    {
        string[] numberNames = { "Zero", "One", "Two", "Three",
            "Four", "Five", "Six", "Seven", "Eight", "Nine"}; 

        return numberNames[num%10];
    }
}