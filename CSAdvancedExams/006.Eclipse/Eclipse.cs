using System;

class Eclipse
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string glassFrame, bridge;
        for (int line = 0; line < size; line++)
        {
            if (line == 0 || line == size - 1)
            {
                glassFrame = " " + new String('*', (size * 2 - 2)) + " ";
            }
            else
            {
                glassFrame = "*" + new String('/', (size * 2 - 2)) + "*";
            }

            if (line == size/2)
            {
                bridge = new String('-', size - 1);
            }
            else
            {
                bridge = new String(' ', size - 1);
            }

            Console.WriteLine("{0}{1}{0}", glassFrame, bridge);
        }
    }
}