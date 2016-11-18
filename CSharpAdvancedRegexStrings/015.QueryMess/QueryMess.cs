//The input comes from the console on a variable number of lines and ends when the keyword 
//"END" is received. For each row of the input, the query string contains pairs field = value.
//Within each pair, the field name and value are separated by an equals sign, '='. The series 
//of pairs are separated by an ampersand, '&'. The question mark is used as a separator and 
//is not part of the query string. A URL query string may contain another URL as value.The 
//input data will always be valid and in the format described.There is no need to check it 
//explicitly.


//Sample input:

//foo=%20foo&value=+val&foo+=5+%20+203
//foo=poo%20&value=valley&dog=wow+
//url=https://softuni.bg/trainings/coursesinstances/details/1070
//https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php
//END



using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class QueryMess
{
    static void Main(string[] args)
    {
        string inLine;
        Dictionary<string, string> storage = new Dictionary<string, string>();
        while ((inLine = Console.ReadLine())!="END")
        {
            storage = new Dictionary<string, string>();
            inLine = inLine.Replace("%20", " ");
            inLine = inLine.Replace("+", " ");
            inLine = Regex.Replace(inLine, @"\s+", " ");
            string pattern = @"([^&?]+)\s*=\s*([^&?]+)[&|\n|\?]*";
            Match m = Regex.Match(inLine, pattern);
            while (m.Success)
            {
                string key = m.Groups[1].Value.Trim();
                string value = m.Groups[2].Value.Trim();

                if (!storage.ContainsKey(key))
                {
                    storage[key] = value;
                }
                else
                {
                    storage[key]+= (", " + value);
                }
                m = m.NextMatch();
            }

            foreach (KeyValuePair<string, string> x in storage)
            {
                Console.Write("{0}=[{1}]", x.Key, x.Value);
            }
            Console.WriteLine();
        }
    }
}