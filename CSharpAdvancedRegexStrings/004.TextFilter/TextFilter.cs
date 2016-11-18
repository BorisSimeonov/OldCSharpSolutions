//Write a program that takes a text and a string of banned words.
//All words included in the ban list should be replaced with 
//asterisks "*", equal to the word's length. The entries in the 
//ban list will be separated by a comma and space ", ".

//Input:
//Linux, Windows
//It is not Linux, it is GNU/Linux.Linux is merely the kernel, 
//while GNU adds the functionality.Therefore we owe it to them by 
//calling the OS GNU/Linux! Sincerely, a Windows client



using System;

class TextFilter
{
    static void Main()
    {
        string[] bannedWords = Console.ReadLine().Replace(" ", "").Split(',');
        string text = Console.ReadLine();
        for (int i = 0; i < bannedWords.Length; i++)
        {
            string censored = new string('*', bannedWords[i].Length);
            text = text.Replace(bannedWords[i], censored);
        }
        Console.WriteLine("\n" + text);
    }
}