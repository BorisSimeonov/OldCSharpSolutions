using System;

class SeniorTrainer : Trainer
{
    public SeniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {

    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2}) - Senior Trainer!",
            this.FirstName, this.LastName, this.Age);
    }

    public void DeleteCourse(string courseName = "Test Name Value - Delete")
    {
        Console.WriteLine(string.Format("{0} {1} deleted course \"{2}\"",
            this.FirstName, this.LastName, courseName));
    }
}