using System;

public class Student
{
    private string name;

    private int grade;

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Trim() != null)
            {
                if (value.Trim().Length < 2)
                {
                    throw new ArgumentException(
                        "name", "The name cnnot be less than 2 characters.");
                }
                this.name = value.Trim();
            }
            else
            {
                throw new ArgumentException(
                    "name", "The name cnnot be NULL.");
            }
        }
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentOutOfRangeException(
                    "grade", "Grade value must be in range between 1-12.");
            }
            this.grade = value;
        }
    }
}