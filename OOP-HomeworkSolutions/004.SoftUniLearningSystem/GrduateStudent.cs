using System;
using System.Globalization;

class GraduateStudent : Student
{
    private DateTime graduateDateField;

    public GraduateStudent(string firstName, string lastName,
        int currentAge, long studentNumber, DateTime graduationDate, double averageGrade = 0.0d) : 
        base(firstName, lastName, currentAge, studentNumber, averageGrade)
    {
        this.GraduationDate = graduationDate;
    }

    public DateTime GraduationDate {
        get { return this.graduateDateField; }
        set
        {
            if (value >= DateTime.ParseExact("01/01/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) &&
                value <= DateTime.Now)
            {
                this.graduateDateField = value;
            }
            else
            {
                throw new FormatException("GraduationDate: Date out of range Exception. (2014-01-01 to Now)");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2})\nStudNumber: \"{3}\"\n" +
            "Average Grade: {4}\nGraduation Date: {5}", this.FirstName, this.LastName,
            this.Age, this.StudentNumber, this.AverageGrade, this.GraduationDate.ToString("dd/MM/yyyy"));
    }
}