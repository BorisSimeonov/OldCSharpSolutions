using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class SlicingFile
{
    static string path = "../../FileSource";
    static string fileName = "";
    static string fileExt = "";
    static bool hasSplitted = false;

    static void Main()
    {
        int parts = 1;
        int.TryParse(Console.ReadLine(), out parts);
        if (parts == 0)
        {
            parts = 1;
        }
        double fileSize = GetFileNameAndSize();
        if (fileSize > 0)
        {
            splitFile((long)fileSize, parts);
        }
        else
        {
            Console.WriteLine("No files found!");
        }
        if (hasSplitted)
        {
            joinAll();
        }
    }

    private static void joinAll()
    {
        string joinPath = "../../JoinDestination";
        string pattern = @"Part_([\d]+)\(([\w]+)\)\.split\s*$";
        List<string> orderedFileList = 
            new List<string>(Directory.GetFiles("../../SplitDestination"));
        orderedFileList = orderedFileList.OrderBy(a => 
        int.Parse(Regex.Match(a, pattern).Groups[1].Value)).ToList();
        orderedFileList.ForEach(p => Console.WriteLine(p));
        string joinExt = Regex.Match(orderedFileList[0], pattern).Groups[2].Value;
        //build file
        FileStream joinStream = new FileStream(
            (joinPath + "/Joined." + joinExt.ToLower()),
            FileMode.Create
            );
        using (joinStream)
        {
            foreach (string partPath in orderedFileList)
            {
                FileStream readPStream = new FileStream(partPath, FileMode.Open);
                while (true)
                {
                    byte[] buffer = new byte[4096];
                    int cnt = readPStream.Read(buffer, 0 ,buffer.Length);
                    if (cnt == 0)
                    {
                        break;
                    }

                    joinStream.Write(buffer, 0, cnt);
                }
            }
        }
    }

    private static double GetFileNameAndSize()
    {
        string[] files = Directory.GetFiles("../../FileSource");
        if (files.Length == 0)
        {
            return 0;
        }
        fileName = files[0]; //work only with the first match
        FileInfo fn = new FileInfo(path + files[0]);
        double fileSize = fn.Length;
        Match m = Regex.Match(fileName, @"\.([\w]+$)");
        fileExt = m.Groups[1].Value;
        return fileSize;
    }

    private static void splitFile(long fileSize, int parts)
    {
        string filePath = fileName;
        string splitPath = "../../SplitDestination";

        Array.ForEach(Directory.GetFiles(splitPath), File.Delete);

        FileStream readStream = new FileStream(filePath, FileMode.Open);

        long counter = 0;
        int partCount = 0;
        string partName = "Part_" + partCount +
            "(" + fileExt + ").split";
        using (readStream)
        {
            bool breakRead = false;
            while (true)
            {
                string destPath = (splitPath + "/" + partName);
                FileStream writeStream = new FileStream(destPath, FileMode.Create);
                using (writeStream)
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int count = readStream.Read(buffer, 0, buffer.Length);
                        if (count != 0)
                        {
                            counter += count;

                            writeStream.Write(buffer, 0, count);
                            if (counter > fileSize / parts)
                            {
                                partCount++;
                                partName = "Part_" + partCount +
                                    "(" + fileExt + ").split";
                                counter = 0;
                                break;
                            }
                        }
                        else
                        {
                            breakRead = true;
                            break;
                        }
                    }
                    if (breakRead)
                    {
                        break;
                    }
                }
            }

        }
        hasSplitted = true;
    }
}