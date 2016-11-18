using System;

public abstract class Animal : ISoundProducible
{
    private string nameField;

    private int ageField;

    private string genderField;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return this.nameField; }
        set
        {
            if (value != null)
            {
                if (value.Trim().Length > 1)
                {
                    this.nameField = value.Trim();
                }
                else
                {
                    throw new FormatException("Name must contain two or more characters.");
                }
            }
            else
            {
                throw new ArgumentNullException("The name cannot be null.");
            }
        }
    }

    public int Age
    {
        get { return this.ageField; }
        set
        {
            if (value >= 0 &&
                value < 100)
            {
                this.ageField = value;
            }
            else
            {
                throw new FormatException("Age cannot be a negative or over 100.");
            }
        }
    }

    public virtual string Gender
    {
        get { return this.genderField; }
        set
        {
            if (value != null)
            {
                if (value.Trim().ToLower() == "male" ||
                    value.Trim().ToLower() == "female")
                {
                    this.genderField = value.Trim().ToLower();
                }
                else
                {
                    throw new FormatException("Gender must be 'male' or 'female'.");
                }
            }
            else
            {
                throw new ArgumentNullException("The gender cannot be null.");
            }
        }
    }

    public override string ToString()
    {
        string printValue = string.Format("Name: {0}, Age: {1}, Gender: {2}",
            this.Name, this.Age, this.Gender);
        return printValue;
    }

    public abstract void prodiceSound(string sound);
}