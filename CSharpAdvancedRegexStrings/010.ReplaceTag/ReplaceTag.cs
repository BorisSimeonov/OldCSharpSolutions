//replace the tag <a> from the input

using System;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main()
    {
        string text = "<ul><li><a href=>SoftUni</a></li></ul>\n"+
            "<ul><li><a href=http://softuni.bg>NextMatch</a></li></ul>";
        text = Regex.Replace(text, @"(<\s*?a\s+)(href=.*?)(>){1}(.*?)(<\/\s*a\s*>)", m => "[URL " + m.Groups[2].Value + 
        "]" + m.Groups[4] + "[/URL]");
        Console.WriteLine(text);
    }
}