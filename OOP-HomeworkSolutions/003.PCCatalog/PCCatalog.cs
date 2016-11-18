using System;
using System.Collections.Generic;

class PCCatalog
{
    static void Main()
    {
        try
        {
            List<Component> compList = new List<Component>();
            compList.Add(new Component("Processor", 645.25m, "Intel Core i7"));
            compList.Add(new Component("RAM DDR3 1600Hz", 145.50m, "Crosshair"));
            compList.Add(new Component("2TB HDD 7200rpm", 123.05m, "Seagate"));
            compList.Add(new Component("Motherboard Gygabite", 79.95m, "P85-D3"));
            compList.Add(new Component("VCard NVidia", 645.25m, "GTX 980"));
            compList.Add(new Component("Network Adapter", 15.25m, "D-Link"));

            //Component textComponent = new Component("Processor", 645.25m, "Intel Core i7");
            //Console.WriteLine(textComponent.Name);
            //Console.WriteLine(textComponent.Price);
            //Console.WriteLine(textComponent.Details);

            Computer myComputer = new Computer("ASUS Ideal Box", compList);
            //myComputer.Components.ForEach(x => Console.WriteLine(x.Name + "\n" + x.Price + "\n" + x.Details + "\n"));
            Console.WriteLine(myComputer);

            Console.WriteLine(myComputer.GetFullPrice());
            Console.WriteLine(myComputer.GetFullPrice(1.7525m, "USD"));
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Source);
            //Console.WriteLine("\n" + e.StackTrace);
            Console.WriteLine("\n" + e.TargetSite);
        }
    }
}