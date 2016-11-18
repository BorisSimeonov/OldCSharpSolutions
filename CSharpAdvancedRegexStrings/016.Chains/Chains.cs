//As input you will receive an HTML document as a single string. You need to get
//the text from all the<p> tags and replace all characters which are not small 
//letters and numbers with a space " ". After that you must decrypt the text – 
//all letters from a to m are converted to letters from n to z(a  n; b  o; … m  z).
//The letters from n to z are converted to letters from a to m(n  a; o  b; … z  m).
//All multiple spaces should then be replaced by only one space.

//For test: string inLine = "<html><head><title></title></head><body><h1>Intro</h1><ul>
//<li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl
//</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl
//rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, 
//do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp
//vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va
//pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p>
//</body>";

using System;
using System.Text.RegularExpressions;

class Chains
{
    static void Main()
    {
        string inLine = Console.ReadLine();
        string pattern = @"<p>(.*?)<\/p>";//@"<p.*?>(.*?)<";
        string pText = "";
        Match m = Regex.Match(inLine, pattern);
        while (m.Success)
        {
            pText += m.Groups[1].Value;
            m = m.NextMatch();
        }
        pText = Regex.Replace(pText, @"[^a-z0-9]", " ");
        char[] chArray = pText.ToCharArray();
        for (int idx = 0; idx < pText.Length; idx++)
        {
            int value = (int)chArray[idx];
            if (value >= 97 && value <= 109)
            {
                chArray[idx] = (char)((int)chArray[idx] + 13);
            }
            else if (value >= 110 && value <= 122)
            {
                chArray[idx] = (char)((int)chArray[idx] - 13);
            }
        }
        pText = string.Join("", chArray);
        pText = Regex.Replace(pText, @"\s+", " ");
        Console.WriteLine(pText);
    }
}
