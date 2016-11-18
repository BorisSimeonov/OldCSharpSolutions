using System;

public abstract class Person : IPerson
{
    private ulong idField;

    private string firstNameField;

    private string lastNameField;

    public Person(string firstName, string lastName, ulong id)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public ulong Id
    {
        get { return this.idField; }
        set
        {
            if (value > 0)
            {
                this.idField = value;
            }
            else
            {
                throw new FormatException("Id can be only long number greater than 0.");
            }
        }
    }

    public string FirstName
    {
        get { return this.firstNameField; }
        set
        {
            if (value != null)
            {
                if (value.Trim().Length > 1)
                {
                    this.firstNameField = value.Trim();
                }
                else
                {
                    throw new FormatException("First name length must be greater than 1");
                }
            }
            else
            {
                throw new ArgumentNullException("First name cannot be null.");
            }
        }
    }

    public string LastName
    {
        get { return this.lastNameField; }
        set
        {
            if (value != null)
            {
                if (value.Trim().Length > 1)
                {
                    this.lastNameField = value.Trim();
                }
                else
                {
                    throw new FormatException("Last name length must be greater than 1");
                }
            }
            else
            {
                throw new ArgumentNullException("Last name cannot be null.");
            }
        }
    }

    public abstract override string ToString();
}