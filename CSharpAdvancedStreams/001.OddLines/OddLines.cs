using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        string path = "../../TextFiles/text.txt";
        StreamReader readStream = new StreamReader(path);
        int lineCounter = 0;
        using (readStream)
        {
            while (true)
            {
                string line = readStream.ReadLine();
                if (line == null)
                {
                    break;
                }
                lineCounter++;
                if (lineCounter % 2 != 0)
                {
                    Console.WriteLine("Line {0}:\n {1}", lineCounter, line);
                }
            }
        }
    }
}