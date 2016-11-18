using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

class CleanUpTheMess
{
    const string readPath = @"..\..\MessedFile\Mecanismo.txt";
    const string writePath = @"..\..\FixedFile\Fixed.cs";
    static string fullText = "";
    static void Main()
    {
        fullText = GetFullCode();
        FormatText();
        WriteFixedFile();

    }

    private static void WriteFixedFile()
    {
        FileStream writeStream = new FileStream(writePath, FileMode.Create);
        using (writeStream)
        {
            byte[] byteText = new UTF8Encoding(true).GetBytes(fullText);
            writeStream.Write(byteText, 0, byteText.Length);
        }
    }

    private static void FormatText()
    {
        string pattern = @"([^\t\r]+)";
        Match m = Regex.Match(fullText, pattern);
        string buffer = "";
        while (m.Success)
        {
            buffer += m.Groups[1].Value;
            m = m.NextMatch();
        }
        buffer = Regex.Replace(buffer, @"(\s+)", " ");
        buffer = Regex.Replace(buffer, @"([\}\{])", "\n$1\n");
        buffer = Regex.Replace(buffer, @"([;])", "$1\n");
        Console.WriteLine(buffer);
        fullText = buffer;
    }

    private static string GetFullCode()
    {
        string text = "";
        StreamReader readFile = new StreamReader(readPath);
        text = readFile.ReadToEnd();
        return text;
    }
}