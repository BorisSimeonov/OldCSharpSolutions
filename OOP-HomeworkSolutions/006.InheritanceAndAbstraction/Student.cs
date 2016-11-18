using System;
using System.Text.RegularExpressions;

class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, 
        string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (value != null)
            {
                if (Regex.IsMatch(value.Trim(), @"^([0-9]{5,10})$"))
                {
                    this.facultyNumber = value.Trim();
                }
                else
                {
                    throw new FormatException(
                        "Faculty number must cointain from 5 to 10 digits"
                        );
                }
            }
            else
            {
                throw new ArgumentNullException("Faculty number cannot be null.");
            }
        }
    }

    public override string GetFullData()
    {
        return string.Format("Name: {0}\nFaculty Number: {1}", 
            this.GetFullName(), this.FacultyNumber);
    }        
}
