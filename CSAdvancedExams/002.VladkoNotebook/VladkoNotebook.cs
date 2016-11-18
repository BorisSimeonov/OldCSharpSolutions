using System;
using System.Collections.Generic;
using System.Linq;

class VladkoNotebook
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inArray;
        Dictionary<string, PlayerInfo> colorPages =
            new Dictionary<string, PlayerInfo>();

        while (input != "END")
        {
            inArray = input.Split('|');
            string color = inArray[0];
            string type = inArray[1];
            string value = inArray[2];

            if (!colorPages.ContainsKey(color))
            {
                colorPages[color] = new PlayerInfo();
            }

            switch (type)
            {
                case "age":
                    colorPages[color].Age = int.Parse(value);
                    break;
                case "name":
                    colorPages[color].Name = value;
                    break;
                case "win":
                    colorPages[color].WinCount += 1;
                    colorPages[color].OpponentNames.Add(value);
                    break;
                case "loss":
                    colorPages[color].LossCount += 1;
                    colorPages[color].OpponentNames.Add(value);
                    break;
            }
            input = Console.ReadLine();
        }

        var ordered = colorPages
            .Where(e => e.Value.Age != 0 && e.Value.Name != null)
            .OrderBy(p => p.Key);

        if (ordered.Count() < 1)
        {
            Console.WriteLine("No data recovered.");
        }
        else
        {
            foreach (var page in ordered)
            {
                Console.WriteLine("Color: {0}", page.Key);
                Console.WriteLine("-age: {0}", page.Value.Age);
                Console.WriteLine("-name: {0}", page.Value.Name);
                Console.WriteLine(page.Value.OpponentNames.Count > 0 ?
                    "-opponents: {0}" :
                    "-opponents: (empty)",
                    string.Join(", ", page.Value.OpponentNames
                    .OrderBy(p => p, StringComparer.Ordinal))
                    );
                Console.WriteLine("-rank: {0:f2}",
                    (double)(page.Value.WinCount + 1) / (page.Value.LossCount + 1)
                    );
            }
        }
    }

    class PlayerInfo
    {
        public PlayerInfo()
        {
            this.OpponentNames = new List<string>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<string> OpponentNames { get; set; }

        public int WinCount { get; set; }

        public int LossCount { get; set; }
    }
}