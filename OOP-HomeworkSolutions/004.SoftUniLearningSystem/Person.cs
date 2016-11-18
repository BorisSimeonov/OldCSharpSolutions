using System;

class Person
{
    private string firstNameField;

    private string lastNameField;

    private int ageField;

    public Person()
    {

    }

    public Person(string firstName, string lastName, int currentAge)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = currentAge;
    }

    public string FirstName
    {
        get { return this.firstNameField; }
        set
        {
            bool isValid = false;
            if(value != null)
            {
                if (value.Trim().Length > 1 && value.Trim().Length <= 10)
                {
                    this.firstNameField = value.Trim();
                    isValid = true;
                }
            }
            if (!isValid)
            {
                throw new FormatException(value == null ? 
                    "Name: Null Value Exception." : 
                    "Name: Name Value Size Exception");
            } 
        }
    }

    public string LastName
    {
        get { return this.lastNameField; }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Trim().Length > 1 && value.Trim().Length <= 10)
                {
                    this.lastNameField = value.Trim();
                    isValid = true;
                }
            }
            if (!isValid)
            {
                throw new FormatException(value == null ?
                    "Name: Null Value Exception." :
                    "Name: Name Value Size Exception");
            }
        }
    }

    public int Age
    {
        get { return this.ageField; }
        set
        {
            if (value > 0 &&
                value < 80)
            {
                ageField = value;
            }
            else
            {
                throw new FormatException("Age: Invalid Age Input. (1-79 alowed)");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} ({2})", 
            this.firstNameField, this.lastNameField, this.ageField);
    }
}
