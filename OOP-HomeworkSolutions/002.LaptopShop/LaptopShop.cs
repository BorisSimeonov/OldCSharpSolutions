using System;

class LaptopShop
{
    static void Main()
    {
        try
        {
            //Laptop lenovo = new Laptop("Lenovo Yoga 2 Pro", 2259.00m);
            //Console.WriteLine(lenovo);
            //Laptop asus = new Laptop("ASUS Pro Tab", 1259.00m, "ASUS");
            //Console.WriteLine(asus);
            //Laptop asusTwo = new Laptop("ASUS Pro Tab", 1259.00m, "ASUS", "Intel Core i5 - 4210U(2 - core, 1.70 - 2.70 GHz, 3MB cache)");
            //Console.WriteLine(asusTwo);
            //Laptop asusThree = new Laptop("ASUS Pro Tab", 1259.00m, "ASUS", "Intel Core i5 - 4210U(2 - core, 1.70 - 2.70 GHz, 3MB cache)",
            //    "16GB DDR3 1600MHz");
            //Console.WriteLine(asusThree);
            //Laptop asusFour = new Laptop("ASUS Pro Tab", 1259.00m, "ASUS", "Intel Core i5 - 4210U(2 - core, 1.70 - 2.70 GHz, 3MB cache)",
            //    "16GB DDR3 1600MHz", "Intel HD Graphics 4400");
            //Console.WriteLine(asusFour);
            //Laptop asusFive = new Laptop("ASUS Pro Tab", 1259.00m, "ASUS", "Intel Core i5 - 4210U(2 - core, 1.70 - 2.70 GHz, 3MB cache)",
            //    "16GB DDR3 1600MHz", "Intel HD Graphics 4400", "4TB HDD 7200RPM");
            //Console.WriteLine(asusFive);
            Laptop asusSix = new Laptop("ASUS Pro Tab", 1259.00m,
                 "ASUS", "Intel Core i5 - 4210U(2 - core, 1.70 - 2.70 GHz, 3MB cache)",
                "16GB DDR3 1600MHz", "Intel HD Graphics 4400", "4TB HDD 7200RPM",
                "13.3\"(33.78 cm) – 3200 x 1800(QHD +), IPS sensor display",
                "Li-Ion, 4-cells, 2550 mAh", 4.5);
            Console.WriteLine(asusSix + "\n");
            Console.WriteLine(asusSix.MandatoryOnly());
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n{1}", e.Message, e.TargetSite);
        }
    }
}