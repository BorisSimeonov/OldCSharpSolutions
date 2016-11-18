using System;
using System.Collections.Generic;

class Phonebook
{
    public static SortedDictionary<string, string> phonebook = 
        new SortedDictionary<string, string>();

    static void Main()
    {
        EnterNamePhones();
        SearchByName();


    }

    static void EnterNamePhones()
    {
        string command;
        while (true)
        {
            command = Console.ReadLine().Trim();
            if (command.ToLower() == "search")
            {
                return;
            }

            string[] pair = command.Replace('+', ' ').Split('-');
            if (!phonebook.ContainsKey(pair[0].Trim()))
            {
                phonebook.Add(pair[0], pair[1]);
            }
            else
            {
                phonebook[pair[0]] += (", " + pair[1]);
            }
        }
    }

    static void SearchByName()
    {
        while (true)
        {
            string name = Console.ReadLine().Trim();
            if (name.ToLower() == "all")
            {
                PrintAll();
                continue;
            }
            else if (name.ToLower() == "end")
            {
                return;
            }
            else
            {
                if (phonebook.ContainsKey(name))
                {
                    Console.Clear();
                    Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                    Console.WriteLine("Type End for exit and All for full list.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Contact {0} does not exist.", name);
                    Console.WriteLine("Type End for exit and All for full list.");
                }
            }
        }
    }

    private static void PrintAll()
    {
        Console.Clear();
        foreach (var x in phonebook)
        {
            Console.WriteLine(x.Key + " - " + x.Value);
        }
        Console.WriteLine("Type End for exit and All for full list.");
        return;
    }
}