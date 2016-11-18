using System;
using System.Text.RegularExpressions;

class StringMatrixRotation
{
    static string[] strArray;
    static void Main()
    {
        int rotation = int.Parse(Regex.Match(Console.ReadLine(),
            @"[0-9]+").ToString()) % 360;
        int maxLength = 0;
        string allInput = "";
        while (true)
        {
            string buffer = Console.ReadLine();
            if (buffer == "END")
            {
                allInput = allInput.Substring(0,allInput.Length - 1);
                break;
            }
            maxLength = Math.Max(buffer.Length , maxLength);
            allInput += (buffer + "\n");
        }
        strArray = allInput.Split('\n');
        for (int idx = 0; idx < strArray.Length; idx++)
        {
            if (strArray[idx].Length < maxLength)
            {
                strArray[idx] += new String(' ', maxLength - strArray[idx].Length);
            }
        }
        RotatedWrite(rotation, maxLength);
    }

    private static void RotatedWrite(int rotation, int maxLength)
    {
        switch (rotation)
        {
            case 0:
                foreach (string x in strArray) { Console.WriteLine(x); };
                break;
            case 90:
                for (int idx = 0; idx < maxLength; idx++)
                {
                    for (int row = strArray.GetLength(0) - 1; row >= 0; row--)
                    {
                        string x = strArray[row];
                        Console.Write(x[idx]);
                    }
                    Console.WriteLine();
                }
                break;
            case 180:
                for (int row = strArray.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int idx = maxLength - 1; idx >= 0; idx--)
                    {
                        Console.Write(strArray[row][idx]);
                    }
                    Console.WriteLine();
                }
                break;
            case 270:
                for (int idx = maxLength - 1; idx >= 0 ; idx--)
                {
                    for (int row = 0; row < strArray.GetLength(0); row++)
                    {
                        Console.Write(strArray[row][idx]);
                    }
                    Console.WriteLine();
                }
                break;

        }
    }
}