using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class FullDirTraversal
{
    static Dictionary<string, List<KeyValuePair<string, string>>> fileDict =
        new Dictionary<string, List<KeyValuePair<string, string>>>();
    static void Main()
    {
        string dirPath = Console.ReadLine();
        getDirs(dirPath);
        List<KeyValuePair<string, List<KeyValuePair<string, string>>>> list = fileDict.ToList();
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

    private static void getDirs(string path)
    {
        var dirs = Directory.GetDirectories(path);
        
        foreach (string x in dirs)
        {
            Console.WriteLine(x + "\n");
            DirectoryInfo dirInfo = new DirectoryInfo(x);
            foreach (var file in dirInfo.GetFiles())
            {
                string name = file.Name;
                string size = (file.Length / 1000.00).ToString();
                string ext = file.Extension;
                if (!fileDict.ContainsKey(ext))
                {
                    fileDict[ext] = new List<KeyValuePair<string, string>>();
                    fileDict[ext].Add(new KeyValuePair<string, string>(name, size + " kb"));
                }
                else
                {
                    fileDict[ext].Add(new KeyValuePair<string, string>(name, size + " kb"));
                }
            }
            getDirs(x);
        }
    }
}