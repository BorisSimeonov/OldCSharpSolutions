using System;

class Person
{
    private string name;

    private int age;

    private string email;

    public Person(string inName, int inAge) : this(inName, inAge, null)
    {

    }

    public Person(string inName, int inAge, string inMail)
    {
        this.Name = inName;
        this.Age = inAge;
        this.Email = inMail;
    }

    public string Name
    {
        get { return this.name; }
        set
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(value,
                @"^[A-Za-z]+\s[A-Za-z]+\s*[A-Za-z]*$"))
            {
                throw new FormatException(
                    "PersonName: Only name in format \"Firstname Middlename Lastname\" " +
                    "is allowed - (last name is optional)");
            }
            name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value > 100 || value < 1)
            {
                throw new IndexOutOfRangeException("Age: The field accept only " +
                    "integer values in range from 1 to 100 including.");
            }
            age = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if (value != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value,
                @"^([a-z0-9_\-]+(\.[a-z0-9_\-]+)*\@[a-z0-9\-]+(\.[a-z0-9_\-]+)*?\.[a-z]{2,})$")
                 || value.Length < 7)
                {
                    throw new FormatException("Email: Invalid Email format " +
                        "(this.1mail.is@in.a-valid.form)");
                }
            }
            email = value;
        }
    }

    public override string ToString()
    {
        return string.Format(this.email != null ?
            "Person Name: {0}; Person Age: {1}; Person E-Mail: {2}" :
            "Person Name: {0}; Person Age: {1}",
            this.Name, this.Age, this.Email);
    }
}