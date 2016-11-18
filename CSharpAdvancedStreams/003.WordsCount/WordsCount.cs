using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class WordsCount
{
    const string wordsPath = "../../TextFiles/words.txt";
    const string textPath = "../../TextFiles/text.txt";
    const string resultPath = "../../TextFiles/result.txt";

    static void Main()
    {
        try
        {
            List<string> wordsList = GetWordsAsArray();
            string text = GetTextAsString();
            GetMatchesAndPrintFile(wordsList, text);

            
        }
        catch
        {
            Console.WriteLine("File is missing.");
        }
    }

    private static void GetMatchesAndPrintFile(List<string> wordsList, string text)
    {
        List<string> resultList = new List<string>();
        for (int idx = 0; idx < wordsList.Count; idx++)
        {
            string wordToLow = wordsList[idx].ToLower();
            string pattern = @"[^\w]*([\w\']+)[^\w]*";
            Match m = Regex.Match(text, pattern);
            int cnt = 0;
            while (m.Success)
            {
                if (m.Groups[1].Value.ToLower() == wordToLow)
                {
                    cnt++;
                }
                m = m.NextMatch();
            }
            resultList.Add(string.Format("{0} - {1}", wordsList[idx], cnt));
        }

        StreamWriter resultWriter = new StreamWriter(resultPath, true, Encoding.UTF8);
        using (resultWriter)
        {
            resultList.ForEach(p => resultWriter.WriteLine(p));
        }
    }

    private static string GetTextAsString()
    {
        StreamReader textReader = new StreamReader(textPath);
        string text = "";
        using (textReader)
        {
            text = textReader.ReadToEnd();
        }
        return text;
    }

    private static List<string> GetWordsAsArray()
    {
        StreamReader wordReader = new StreamReader(wordsPath,
            Encoding.ASCII, false, 4096);
        using (wordReader)
        {
            string buffer = wordReader.ReadToEnd();
            if (buffer != "")
            {
                buffer = buffer.Trim();
                string pattern = @"[\w]+";
                Regex reg = new Regex(pattern);
                List<string> wordList = new List<string>();
                foreach (Match match in reg.Matches(buffer))
                {
                    wordList.Add(match.Value);
                }
                return wordList;
            }
        }
        return new List<string>();
    }
}