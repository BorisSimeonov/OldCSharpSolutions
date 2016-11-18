using System;

public abstract class Human
{
    private string firstName;

    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (value != null)
            {
                if (value.Length > 1)
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First Name Length Must Be 2 0r More Characters.");
                }
            }
            else
            {
                throw new ArgumentNullException("First Nme cannot be null.");
            }
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (value != null)
            {
                if (value.Length > 1)
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last Name Length Must Be 2 0r More Characters.");
                }
            }
            else
            {
                throw new ArgumentNullException("Last Name cannot be null.");
            }
        }
    }

    public string GetFullName()
    {
        string fullName = string.Format(
            "{0} {1}", this.firstName, this.lastName);
        return fullName;
    }

    public abstract string GetFullData();
}