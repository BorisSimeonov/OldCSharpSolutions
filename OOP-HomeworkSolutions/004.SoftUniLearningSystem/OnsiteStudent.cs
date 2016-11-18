using System;

class OnsiteStudent : CurrentStudent
{
    private int visitsField = 0;

    public OnsiteStudent(string firstName, string lastName, int currentAge, long studentNumber, 
        string currentCourse, int visitCount, double averageGrade = 0.0d) :
        base(firstName, lastName, currentAge, studentNumber, currentCourse, averageGrade)
    {
        this.Visits = visitCount;
    }

    public int Visits
    {
        get { return this.visitsField; }
        set
        {
            if (value >= 0)
            {
                this.visitsField = value;
            }
            else
            {
                throw new FormatException("Visits: Out Of range.");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2})\nStudNumber: \"{3}\"\n" +
            "Average Grade: {4}\nCurrent Course: {5}\nVisits: {6}", this.FirstName, this.LastName,
            this.Age, this.StudentNumber, this.AverageGrade,
            this.CurrentCourse, this.Visits);
    }
}