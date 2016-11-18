using System;

class CurrentStudent : Student
{
    private string currentCourseField;

    public CurrentStudent(string firstName, string lastName,
        int currentAge, long studentNumber, string currentCourse, double averageGrade = 0.0d) :
        base(firstName, lastName, currentAge, studentNumber, averageGrade)
    {
        this.CurrentCourse = currentCourse;
    }

    public string CurrentCourse
    {
        get { return this.currentCourseField; }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Trim().Length > 3 &&
                    value.Trim().Length < 25)
                {
                    this.currentCourseField = value.Trim();
                    isValid = true;
                }
            }

            if(!isValid)
            {
                throw new FormatException(value == null ?
                    "CourseName: Null Value Exception." :
                    "CourseName: Name Length Out Of Range.");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2})\nStudNumber: \"{3}\"\n" +
            "Average Grade: {4}\nCurrent Course: {5}", this.FirstName, this.LastName,
            this.Age, this.StudentNumber, this.AverageGrade, 
            this.CurrentCourse);
    }
}