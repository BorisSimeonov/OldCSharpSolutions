using System;

class OnlineStudent : CurrentStudent
{
    private decimal lastPaymentField;

    public OnlineStudent(string firstName, string lastName, int currentAge, 
        long studentNumber, string currentCourse, decimal lastPayment, double averageGrade = 0.0d) :
        base(firstName, lastName, currentAge, studentNumber, currentCourse, averageGrade)
    {
        this.LastPayment = lastPayment;
    }

    public decimal LastPayment
    {
        get { return this.lastPaymentField; }
        set
        {
            if (value > 0)
            {
                this.lastPaymentField = value;
            }
            else
            {
                throw new FormatException(value == 0 ? 
                    "LastPayment: Zero Exception." :
                    "LastPayment: Negative Exception.");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2})\nStudNumber: \"{3}\"\n" +
            "Average Grade: {4}\nCurrent Course: {5}\nLast Payment: {6}lv.",
            this.FirstName, this.LastName, this.Age, this.StudentNumber, 
            this.AverageGrade, this.CurrentCourse, this.LastPayment);
    }
}