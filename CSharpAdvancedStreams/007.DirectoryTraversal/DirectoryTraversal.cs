using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DirectoryTraversal
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, List<KeyValuePair<string, string>>> filesDict =
            new Dictionary<string, List<KeyValuePair<string, string>>>();
        string ext = "", name = "", size = "";

        DirectoryInfo dir = new DirectoryInfo(input);
        Console.WriteLine(dir.FullName);
        foreach (FileInfo x in dir.GetFiles())
        {
            ext = x.Extension;
            name = x.Name;
            size = (x.Length / 1000.00).ToString() ;
            if (ext != name)
            {
                if (!filesDict.ContainsKey(ext))
                {
                    filesDict[ext] = new List<KeyValuePair<string, string>>();
                    filesDict[ext].Add(new KeyValuePair<string, string>(name, size + " kb"));
                }
                else
                {
                    filesDict[ext].Add(new KeyValuePair<string, string>(name, size + " kb"));
                }
            }
        }
        List<KeyValuePair<string, List<KeyValuePair<string,string>>>> list = filesDict.ToList();
        list = list.OrderBy(p => p.Key).OrderByDescending(p => p.Value.Count).ToList();


        FileStream writeStream = new FileStream(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + 
            "/result.txt", FileMode.Create);
        using (writeStream)
        {
            foreach (var x in list)
            {
                byte[] keyBuffer = Encoding.UTF8.GetBytes(x.Key + Environment.NewLine);
                writeStream.Write(keyBuffer, 0, keyBuffer.Length);
                foreach (var y in x.Value)
                {
                    byte[] valueBuffer = Encoding.UTF8.GetBytes("--" + y.Key + " - " + y.Value + Environment.NewLine);
                    writeStream.Write(valueBuffer, 0, valueBuffer.Length);
                }
            }
        }  
    }
}