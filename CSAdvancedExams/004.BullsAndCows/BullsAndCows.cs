using System;
using System.Collections.Generic;
using System.Linq;

class BullsAndCows
{
    static List<int> number;
    static List<string> matches = new List<string>();
    static int bulls, cows;
    static bool hasMatches = false;

    static void Main()
    {
        number = Console.ReadLine()
            .ToCharArray()
            .Select(numChar =>
            {
                int numValue = int.Parse(numChar.ToString())
                ; return numValue;
            }).ToList();

        bulls = int.Parse(Console.ReadLine());
        cows = int.Parse(Console.ReadLine());

        List<int> guessNum;

        for (int fst = 1; fst <= 9; fst++)
        {
            for (int snd = 1; snd <= 9; snd++)
            {
                for (int trd = 1; trd <= 9; trd++)
                {
                    for (int frth = 1; frth <= 9; frth++)
                    {
                        guessNum = new List<int>() {fst, snd , trd, frth };
                        CheckGuessNum(guessNum);
                    }
                }
            }
        }

        Console.WriteLine(hasMatches ? string.Join(" ", matches) : "No");
    }

    private static void CheckGuessNum(List<int> guessNum)
    {
        List<int> checker = new List<int>();
        checker.Add(number[0]);
        checker.Add(number[1]);
        checker.Add(number[2]);
        checker.Add(number[3]);

        List<int> guessBuffer = new List<int>() { guessNum[0], guessNum[1], guessNum[2], guessNum[3] };

        int[] bullCowCount = new int[2] { 0, 0 };
        
        
        //check bulls and remove matches from the number clones
        for (int idx = 0; ; idx++)
        {
            if (checker[idx] == guessBuffer[idx])
            {
                bullCowCount[0]++;
                checker.RemoveAt(idx);
                guessBuffer.RemoveAt(idx);
                idx--;
            }

            if (idx >= checker.Count()-1)
            {
                break;
            }
        }

        if (bullCowCount[0] != bulls)
        {
            return;
        }

        //check cows count and replace with zeores the matching values
        //the zero values prevents from multiple selects of one index during the check
        for (int idx = 0; idx < guessBuffer.Count(); idx++ )
        {
            if (checker.Contains(guessBuffer[idx]))
            {
                bullCowCount[1]++;
                checker[checker.IndexOf(guessBuffer[idx])] = 0;
            }
        }

        if (bullCowCount[1] == cows && bullCowCount[0] == bulls)
        {
            matches.Add(string.Join("", guessNum));
            hasMatches = true;
        }
    }
}