using System;

class Kitten : Cat
{
    private string genderField;

    public Kitten(string name, int age, string gender)
        : base(name, age, gender)
    {
           
    }

    public override string Gender
    {
        get
        {
            return this.genderField;
        }

        set
        {
            if (value != null)
            {
                if (value.Trim().ToLower() == "female")
                {
                    this.genderField = value.Trim().ToLower();
                }
                else
                {
                    throw new FormatException("Gender must be 'female'.");
                }
            }
            else
            {
                throw new ArgumentNullException("The gender cannot be null.");
            }
        }
    }

    public override void prodiceSound(string sound = "Some female cat sound.")
    {
        Console.WriteLine(sound);
    }
}