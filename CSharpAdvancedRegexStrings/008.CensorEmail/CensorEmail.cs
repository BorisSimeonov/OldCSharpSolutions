using System;

class CensorEmail
{
    static void Main()
    {
        string eMail = Console.ReadLine().Trim();
        string[] eParts = eMail.Split('@');
        string replValue = new String('*', eParts[0].Length);
        string text = Console.ReadLine().Replace(eMail, replValue + "@" + eParts[1]);
        Console.WriteLine("\nCensored text:\n{0}", text);       
    }
}