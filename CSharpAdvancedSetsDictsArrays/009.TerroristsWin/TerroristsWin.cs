//A bomb is a string in the format |...|. When set off, 
//the bomb destroys all characters inside.The bomb should 
//also destroy n characters to the left and right of the 
//bomb. n is determined by the bomb power (the last digit 
//of the ASCII sum of the characters inside the bomb). 
//Destroyed characters should be replaced by '.' (dot). 
//For example, we are given the following text:
//    prepare|yo|dong
//The bomb is |yo|. We get the bomb power by calculating 
//the last digit of the sum: y(121) + o(111) = 232. The 
//bomb explodes and destroys itself and 2 characters to 
//the left and 2 characters to the right.The result is:
//    prepa........ng

using System;

class TerroristsWin
{
    static char[] inputText;
    static int bombStart, bombEnd;

    static void Main()
    {
        inputText = Console.ReadLine().ToCharArray();
        FindBombsAndBlast();

        Console.WriteLine(string.Join("", inputText));
    }

    static void FindBombsAndBlast()
    {
        for (int idx = 0; idx < inputText.Length; idx++)
        {
            if (inputText[idx] != '|')
            {
                continue;
            }
            else
            {
                idx = BlastTheBomb(idx);
                continue;
            }
        }
    }

    private static int BlastTheBomb(int idx)
    {
        bombStart = idx;
        int sum = 0;
        int bombIdx = idx + 1;
        while (true)
        {
            char currentCh = inputText[bombIdx];
            if (currentCh == '|')
            {
                bombEnd = bombIdx;
                break;
            }
            else
            {
                sum += (int)inputText[bombIdx];
                bombIdx++;
            }
        }
        sum = sum % 10;

        for (int x = bombStart - sum; x <= bombEnd + sum; x++)
        {
            if (x < 0 || x > inputText.Length - 1)
            {
                continue;
            }
            else
            {
                inputText[x] = '.';
            }
        }

        return (bombEnd+sum);
    }
}