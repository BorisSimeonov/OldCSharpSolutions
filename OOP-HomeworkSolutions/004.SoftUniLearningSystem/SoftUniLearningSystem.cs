using System;

class SoftUniLearningSystem
{
    static void Main()
    {
        try
        {
            //SeniorTrainer testTrainer = new SeniorTrainer("John", "Doe", 24);
            //Console.WriteLine(testPerson);
            //testPerson.DeleteCourse("C# Fundamentals");

            //Student testStudent = new Student("John", "Doe", 33, 122312);
            //Console.WriteLine(testStudent);

            //GraduateStudent gTest = new GraduateStudent("John", "Doe", 33, 122312,
            //    DateTime.ParseExact("01/01/2014", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //gTest.FirstName = "Pesho";
            //Console.WriteLine(gTest);

            //DropoutStudent gTest = new DropoutStudent("John", "Doe", 33, 122312,
            //    DateTime.ParseExact("01/01/2014", "dd/MM/yyyy", 
            //    System.Globalization.CultureInfo.InvariantCulture), "Low Grades",2.333442);
            //gTest.FirstName = "Pesho";
            //Console.WriteLine(gTest);

            //CurrentStudent gTest = new CurrentStudent("John", "Doe", 33, 122312,
            //   "Web Fundamentals", 2.333442);
            //gTest.FirstName = "Pesho";
            //Console.WriteLine(gTest);

            //OnlineStudent gTest = new OnlineStudent("John", "Doe", 33, 122312,
            //   "Web Fundamentals", 655.12m, 2.333442);
            //gTest.FirstName = "Pesho";
            //Console.WriteLine(gTest);

            OnsiteStudent gTest = new OnsiteStudent("John", "Doe", 33, 122312,
               "Web Fundamentals", 24, 2.333442);
            gTest.FirstName = "Pesho";
            Console.WriteLine(gTest);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Source);
            //Console.WriteLine("\n" + e.StackTrace);
            Console.WriteLine("\n" + e.TargetSite);
        }
    }
}