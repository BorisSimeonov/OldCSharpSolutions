using System;

class Trainer : Person
{
    public Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {

    }

    public void CreateCourse(string courseName = "Test Name Value")
    {
        Console.WriteLine(string.Format("{0} {1} created course \"{2}\"",
            this.FirstName, this.LastName, courseName));
    }
}