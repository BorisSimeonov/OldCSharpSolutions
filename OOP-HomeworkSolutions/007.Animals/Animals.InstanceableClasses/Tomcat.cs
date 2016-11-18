using System;

class Tomcat : Animal
{
    private string genderField;

    public Tomcat(string name, int age, string gender)
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
                if (value.Trim().ToLower() == "male")
                {
                    this.genderField = value.Trim().ToLower();
                }
                else
                {
                    throw new FormatException("Gender must be 'male'.");
                }
            }
            else
            {
                throw new ArgumentNullException("The gender cannot be null.");
            }
        }
    }

    public override void prodiceSound(string sound = "Some male cat sound.")
    {
        Console.WriteLine(sound);
    }
}