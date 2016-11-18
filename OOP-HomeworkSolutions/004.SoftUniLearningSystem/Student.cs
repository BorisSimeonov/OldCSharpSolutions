using System;

class Student : Person
{
    private long studentNumberfield;

    private double averageGradeField = 1.0d;

    public Student(string firstName, string lastName, 
        int currentAge, long studentNumber, double averageGrade = 0.0d) : base(firstName, lastName, currentAge)
    {
        this.StudentNumber = studentNumber;
        this.AverageGrade = averageGrade;
    }

    public long StudentNumber
    {
        get { return this.studentNumberfield; }
        set
        {
            if (value > 0)
            {
                this.studentNumberfield = value;
            }
            else
            {
                throw new FormatException("Student Number: Invalid number value.");
            }
        }
    }

    public double AverageGrade
    {
        get { return this.averageGradeField; }
        set
        {
            if (value >= 0.0d)
            {
                averageGradeField = Math.Round(value, 3);
            }
            else
            {
                throw new FormatException("AVG Grade: Negative Input Exception.");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2})\nStudNumber: \"{3}\"\n" + 
            "Average Grade: {4}", this.FirstName, this.LastName, 
            this.Age, this.StudentNumber, this.AverageGrade);
    }
}