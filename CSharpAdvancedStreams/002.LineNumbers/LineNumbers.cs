using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LineNumbers
{
    const string readPath = "../../TextFiles/text.txt";
    const string writePath = "../../TextFiles/newText.txt";
    static void Main()
    {
        StreamReader stReader = new StreamReader(readPath, Encoding.UTF8, false, 4096);
        StreamWriter stWriter = new StreamWriter(writePath);
        int lineCounter = 0;
        using (stReader)
        {
            using (stWriter)
            {
                while (true)
                {
                    string buffer = stReader.ReadLine();
                    if (buffer == null)
                    {
                        break;
                    }
                    lineCounter++;
                    stWriter.WriteLine(string.Format("->{0,5}.\t{1}", lineCounter, buffer));
                }
            }
        }
    }
}