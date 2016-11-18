using System;
using System.Collections.Generic;

class CompanyHierarchy
{
    static void Main()
    {
        //--------------------------- Cust. check

        //Customer textCustom = new Customer("John", "Doe", 122231222, 23.1223m);
        //Console.WriteLine(textCustom);

        //--------------------------- SalesEmployee/sales check

        //List<Sale> salesList = new List<Sale>() {
        //    new Sale("Windows 10 Pro", DateTime.Now, 243.25m),
        //    new Sale("Windows 7 Home", DateTime.Now, 123.15m),
        //    new Sale("Windows 10 Home", DateTime.Now, 210.25m),
        //    new Sale("MS SQL Server", DateTime.Now, 543.25m),
        //    new Sale("Windows 8.1 Pro", DateTime.Now, 189.25m),
        //};
        //SalesEmployee testSalesEmp = new SalesEmployee(
        //    "John", "Doe", 12231, "Sales", 1430.10m, salesList);
        //Console.WriteLine(testSalesEmp);

        //--------------------------- Developer check

        //List<Project> projectList = new List<Project>() {
        //    new Project("Database App", DateTime.Now, "With MS SQL", true),
        //    new Project("Mobile App", DateTime.Now, "Small home Pooject", true),
        //    new Project("Desktop App", DateTime.Now, "", true),
        //    new Project("Linux App", DateTime.Now, "No Info", true),
        //};

        //Developer testDev = new Developer(
        //    "John", "Doe", 12231, "Sales", 1430.10m, projectList);
        //Console.WriteLine(testDev);

        //--------------------------- Manager check

        List<Project> projectList = new List<Project>() {
            new Project("Database App", DateTime.Now, "With MS SQL", true),
            new Project("Mobile App", DateTime.Now, "Small home Pooject", true),
            new Project("Desktop App", DateTime.Now, "", true),
            new Project("Linux App", DateTime.Now, "No Info", true),
        };
        List<Sale> salesList = new List<Sale>() {
            new Sale("Windows 10 Pro", DateTime.Now, 243.25m),
            new Sale("Windows 7 Home", DateTime.Now, 123.15m),
            new Sale("Windows 10 Home", DateTime.Now, 210.25m),
            new Sale("MS SQL Server", DateTime.Now, 543.25m),
            new Sale("Windows 8.1 Pro", DateTime.Now, 189.25m),
        };

        List<RegularEmployee> empList = new List<RegularEmployee>() {
            new SalesEmployee("John", "Doe", 12231, "Sales", 1430.10m, salesList),
            new Developer("John", "DevDoe", 12231, "Production", 1430.10m, projectList),
            new SalesEmployee("Ivan", "Genov", 12231, "Sales", 4430.10m, salesList),
            new Developer("Atanas", "DevPetrov", 12231, "Production", 1430.10m, projectList),
            new SalesEmployee("Johnny", "Blanks", 12231, "Sales", 3430.10m, salesList),
            new SalesEmployee("Billy", "Holms", 12231, "Sales", 2430.10m, salesList)
        };

        Manager testManager = new Manager("John", "Doe", 12231, "Sales", 1430.10m, empList);
        Console.WriteLine(testManager);
    }
}