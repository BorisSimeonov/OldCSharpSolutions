using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Storage
{
    public static void StorePath(Path3D path, string fileName)
    {
        string filePath = string.Format(@"..\..\StorageFolder\{0}.txt", fileName);
        FileStream writeStream = new FileStream(filePath, FileMode.Create);
        string lineHolder = "";
        using (writeStream)
        {
            for (int x = 0; x < path.GetLength(); x++)
            {
                lineHolder = string.Format("{0} {1} {2}{3}",
                    path[x].XAxis, path[x].YAxis, path[x].ZAxis,
                    Environment.NewLine);
                byte[] buffer = new UTF8Encoding(true).GetBytes(lineHolder);
                writeStream.Write(buffer, 0, buffer.Length);
            }
        }
    }

    public static Path3D GetPathFromFile(string fileName)
    {
        string folderPath = string.Format(@"..\..\StorageFolder\{0}.txt",
            fileName);
        Path3D extractedPath = null;
        Point3D bufferPoint;
        List<Point3D> extractedList = new List<Point3D>();
        StreamReader readFile = new StreamReader(folderPath);
        using (readFile)
        {
            while (true)
            {
                string line = readFile.ReadLine();
                if (line == null)
                {
                    break;
                }
                MatchCollection values = Regex.Matches(line, @"(\-{0,1}[0-9]+(\.{0,1}[0-9]+)*)");
                if (values.Count == 3)
                {
                    double x = Double.Parse(values[0].ToString());
                    double y = Double.Parse(values[1].ToString());
                    double z = Double.Parse(values[2].ToString());
                    bufferPoint = new Point3D(x, y, z);
                    extractedList.Add(bufferPoint);
                }
            }
        }
        if (extractedList.Count > 0)
        {
            extractedPath = new Path3D(extractedList);
        }
        return extractedPath;
    }
}