//Must be fixed
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;

class ZippintSlicedFiles
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
        CompressFile();
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

    private static void CompressFile()
    {
        FileInfo[] dir = new DirectoryInfo("../../FileSource").GetFiles();

        using (FileStream readFileStream = dir[0].OpenRead())
        {
            if ((File.GetAttributes(dir[0].FullName) &
                   FileAttributes.Hidden) != FileAttributes.Hidden & dir[0].Extension != ".gz")
            {
                string createPath = "../../FullZip\\ZippedFile.gz";
                using (FileStream cWriteStream = File.Create(createPath))
                {
                    using (GZipStream compressionStream = new GZipStream(cWriteStream,
                           CompressionMode.Compress))
                    {
                        readFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }
    }

    private static void joinAll()
    {
        string joinPath = "../../JoinDestination";
        string pattern = @"Part_([\d]+)\(([\w]+)\)\.gz\s*$";
        List<string> orderedFileList =
            new List<string>(Directory.GetFiles("../../SplitDestination"));
        orderedFileList = orderedFileList.OrderBy(a =>
        int.Parse(Regex.Match(a, pattern).Groups[1].Value)).ToList();
        orderedFileList.ForEach(p => Console.WriteLine(p));
        string joinExt = Regex.Match(orderedFileList[0], pattern).Groups[2].Value;
        //build file
        FileStream joinStream = new FileStream(
            (joinPath + "/Joined.gz"),
            FileMode.Create
            );
        using (joinStream)
        {

            foreach (string partPath in orderedFileList)
            {
                FileStream readPStream = new FileStream(partPath, FileMode.Open);
                using (readPStream)
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int cnt = readPStream.Read(buffer, 0, buffer.Length);
                        if (cnt == 0)
                        {
                            break;
                        }

                        joinStream.Write(buffer, 0, cnt);
                    }
                }
            }
        }
        Decompress();
    }

    private static void Decompress()
    {
        DirectoryInfo directorySelected = new DirectoryInfo("../../JoinDestination");
        foreach (var x in directorySelected.GetFiles())
        {
            if (x.Extension == ".gz")
            {
                Console.WriteLine(x.Extension);
                using (FileStream originalFileStream = x.OpenRead())
                {
                    string newName = x.FullName.Substring(0, x.FullName.Length - 2) + fileExt;
                    Console.WriteLine(newName);
                    using (FileStream writeDecStream = File.Create(newName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(writeDecStream);
                        }
                    }
                }
            };
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
        FileInfo[] dir = new DirectoryInfo("../../FullZip").GetFiles();
        Console.WriteLine(dir[0].FullName);
        string filePath = dir[0].FullName;
        string splitPath = "../../SplitDestination";

        Array.ForEach(Directory.GetFiles(splitPath), File.Delete);

        FileStream readStream = new FileStream(filePath, FileMode.Open);

        long counter = 0;
        int partCount = 0;
        string partName = "Part_" + partCount +
            "(" + fileExt + ").gz";
        using (readStream)
        {
            bool breakRead = false;

            while (true)
            {
                string destPath = (splitPath + "/" + partName);
                FileStream writeStream = new FileStream(destPath, FileMode.Create);

                using (writeStream)
                {
                    using (GZipStream zipStream = new GZipStream(writeStream,
                        CompressionMode.Compress, false))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int count = readStream.Read(buffer, 0, buffer.Length);
                            if (count != 0)
                            {
                                counter += count;

                                zipStream.Write(buffer, 0, count);
                                if (counter > fileSize / parts)
                                {
                                    partCount++;
                                    partName = "Part_" + partCount +
                                        "(" + fileExt + ").gz";
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

        }
        hasSplitted = true;
    }
}