using System;

class DropoutStudent : Student
{
    private DateTime dropoutDateField;

    private string reasonField;

    public DropoutStudent(string firstName, string lastName,
        int currentAge, long studentNumber, DateTime dropoutDate, string reason,
        double averageGrade = 0.0d) : 
        base(firstName, lastName, currentAge, studentNumber, averageGrade)
    {
        this.DropoutDate = dropoutDate;
        this.Reason = reason;
    }

    public DateTime DropoutDate
    {
        get { return this.dropoutDateField; }
        set
        {
            if (value >= DateTime.ParseExact("01/01/2014", "dd/MM/yyyy", 
                System.Globalization.CultureInfo.InvariantCulture) &&
                value <= DateTime.Now)
            {
                this.dropoutDateField = value;
            }
            else
            {
                throw new FormatException("DropoutDate: Date out of range Exception. (2014-01-01 to Now)");
            }
        }
    }

    public string Reason
    {
        get { return this.reasonField; }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Trim().Length > 0 &&
                    value.Trim().Length < 30)
                {
                    this.reasonField = value.Trim();
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value != null ? 
                    "Reason: Invalid Text Length.":
                    "Reason: Null Value Exception.");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2})\nStudNumber: \"{3}\"\n" +
            "Average Grade: {4}\nDropout Date: {5}\nDropout Reason: {6}", this.FirstName, this.LastName,
            this.Age, this.StudentNumber, this.AverageGrade, this.DropoutDate.ToString("dd/MM/yyyy"),
            this.reasonField);
    }
}