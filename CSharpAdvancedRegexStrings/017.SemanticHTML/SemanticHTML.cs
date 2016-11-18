//You are given an HTML code, written in the old non-semantic style using tags 
//like<div id="header">, <div class="section">, etc.Your task is to write a 
//program that converts this HTML to semantic HTML by changing tags like 
//<div id = "header" > to their semantic equivalent like <header>.

    
//The non-semantic tags that should be converted are always <div>s and have either
//id or class with one of the following values: "main", "header", "nav", "article",
//"section", "aside" or "footer". Their corresponding closing tags are always 
//followed by a comment like<!-- header -->, <!-- nav -->, etc.staying at the same
//line, after the tag.


//Example input:
//<p class = "section" >
//    <div style = "border: 1px" id = "header" >
//        Header
//        <div id = "nav" >
//            Nav
//        </div>   <!--   nav   -->
//    </div>  <!--header-->
//  </p> <!-- end paragraph section -->
//END

using System;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {
        string inLine;
        while ((inLine = Console.ReadLine()) != "END")
        {
            checkLine(inLine);
        }
    }

    private static void checkLine(string inLine)
    {
        string patternOne = "<div(.*)(\\s+class\\s*=\\s*\"|\\s+id\\s*=\\s*\"){1}(.*?)([\"].*?>)";
        string patternTwo = @"(<\/div.*?)>\s*<!--\s*(\w+)\s*-->";
        //check first match
        Match firstM = Regex.Match(inLine, patternOne);
        if (firstM.Success)
        {
            if (firstM.Groups[1].Value.Length > 0 && firstM.Groups[4].Value.Length > 0)
            {
                inLine = Regex.Replace(inLine, patternOne, e => "<" + e.Groups[3].Value + " " +
                e.Groups[1].Value.Substring(0, e.Groups[1].Value.Length).Trim() + " " +
                e.Groups[4].Value.Substring(1, e.Groups[4].Value.Length - 1).Trim());
            }
            else if (firstM.Groups[1].Value.Length <= 0 && firstM.Groups[4].Value.Length > 0)
            {
                inLine = Regex.Replace(inLine, patternOne, e => "<" + e.Groups[3].Value + " " +
                e.Groups[4].Value.Substring(1, e.Groups[4].Value.Length - 1).Trim());
            }
            else if (firstM.Groups[4].Value.Length <= 0 && firstM.Groups[1].Value.Length > 0)
            {
                inLine = Regex.Replace(inLine, patternOne, e => "<" + e.Groups[3].Value + " " +
                e.Groups[1].Value.Substring(0, e.Groups[1].Value.Length - 2).Trim());
            }


            inLine = Regex.Replace(inLine, @"\s+>", ">");
            inLine = Regex.Replace(inLine, @"\s+", " ");
            Console.WriteLine(inLine);
            return;
        }

        //check second match
        Match secondM = Regex.Match(inLine, patternTwo);
        if (secondM.Success)
        {
            inLine = Regex.Replace(inLine, patternTwo, e => "</" + e.Groups[2].Value.Trim() + ">");
            Console.WriteLine(inLine);
            return;
        }
        //print if no match
        Console.WriteLine(inLine);
    }
}