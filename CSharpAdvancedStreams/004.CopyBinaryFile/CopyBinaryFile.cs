using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CopyBinaryFile
{
    static string readPath = "";
    static string writePath = "";
    static void Main()
    {
        List<string> files = Directory.GetFiles("../../FileFolder/").ToList();
        for (int x = 0; x < files.Count; x++)
        {
            string pattern = @"([^\/]+\.[\w]+)$";
            Match m = Regex.Match(files[x], pattern);
            files[x] = m.Groups[1].Value;
            Console.WriteLine(files[x]);
        }
        foreach (string fileName in files)
        {
            readPath = "../../FileFolder/" + fileName;
            string fileNameBuffer = fileName;
            int counter = 0;
            string pattern = @"(Copy)\((\d+)\)([^\/]+\.[\w]+)$";
            Match m = Regex.Match(fileNameBuffer, pattern);

            if (m.Success)
            {
                counter = int.Parse(m.Groups[2].Value) + 1;
                while (true)
                {
                    fileNameBuffer = m.Groups[1].Value + "(" +
                        counter +
                        ")" + m.Groups[3].Value;
                    Console.WriteLine(fileNameBuffer);
                    if (!File.Exists("../../FileFolder/" + fileNameBuffer))
                    {
                        break;
                    }
                    counter++;
                }
            }
            else
            {
                fileNameBuffer = "Copy(1)" + fileName;
                if (File.Exists("../../FileFolder/" + fileNameBuffer))
                {
                    m = Regex.Match(fileNameBuffer, pattern);
                    counter = int.Parse(m.Groups[2].Value) + 1;
                    while (true)
                    {
                        fileNameBuffer = m.Groups[1].Value + "(" +
                            counter + ")" + m.Groups[3].Value;
                        Console.WriteLine(fileNameBuffer);
                        if (!File.Exists("../../FileFolder/" + fileNameBuffer))
                        {
                            break;
                        }
                        counter++;
                    }
            }
        }
        writePath = "../../FileFolder/" + fileNameBuffer;

        FileStream readStream = new FileStream(readPath, FileMode.Open);
        FileStream writeStream = new FileStream(writePath, FileMode.CreateNew);
        using (readStream)
        {
            using (writeStream)
            {
                byte[] buffer = new byte[4096];
                int read = 0;
                while ((read = readStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writeStream.Write(buffer, 0, read);
                }
            }
        }
    }
}
}