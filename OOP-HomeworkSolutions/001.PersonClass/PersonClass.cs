using System;

class PersonClass
{
    static void Main()
    {
        Person firstPerson, secondPerson/*, thirdPerson, fourthPerson*/;
        try
        {
            firstPerson = new Person("Boris Simeonov", 27);
            Console.WriteLine("1\t" + firstPerson);                 //first class constructor => second class constructor (e-mail == null)

            secondPerson = new Person("John Doe Fst", 2, "email.address@education.edu.uk");
            Console.WriteLine("2\t" + secondPerson);                //sec. class constructor

            //thirdPerson = new Person("John Doe Snd", 200);
            //Console.WriteLine("3\t" + thirdPerson);               //Invalid Age

            //fourthPerson = new Person("John Doe Trd", 29, "*this.1mail.is@in.a-valid.form");
            //Console.WriteLine("4\t" + fourthPerson);              //Invalid e-mail (*)
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.TargetSite);
        }
    }
}