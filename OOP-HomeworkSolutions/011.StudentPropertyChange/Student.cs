public delegate void OnPropertyChangeEventHandler(string propertyName,
    string propertyOldValue, string propertyNewValue);

class Student
{
    public event OnPropertyChangeEventHandler propertyChaged;

    private string name;

    private int age;

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    private void Student_propertyChaged(string propName, string propValue, string message)
    {
        throw new System.NotImplementedException();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentOutOfRangeException("name",
                    "The name cannot be null, empty or white space/s/.");
            }
            else if (value.Trim().Length < 2)
            {
                throw new System.ArgumentOutOfRangeException("name",
                    "The name must be 2 or more characters.");
            }
            if (this.propertyChaged != null)
            {
                this.propertyChaged("Name", this.Name, value.Trim());
            }
            
            this.name = value.Trim();
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 6 || value > 90)
            {
                throw new System.ArgumentOutOfRangeException("age",
                    "Age cannot be number lower than 6 and higher than 90.");
            }

            if (this.propertyChaged != null)
            {
                this.propertyChaged(
                    "Age", this.Age.ToString(), value.ToString());
            }
            this.age = value;
        }
    }
}