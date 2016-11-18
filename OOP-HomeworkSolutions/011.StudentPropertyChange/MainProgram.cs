using System;

class MainProgram
{
    static void Main()
    {
        Student testStudent = new Student("Pesho", 22);
        testStudent.propertyChaged += OnPropertyChage;

        testStudent.Name = "Ivan";
        testStudent.Age = 44;
        testStudent.Age = 21;
    }

    private static void OnPropertyChage(string propertyName,
    string propertyOldValue, string propertyNewValue)
    {
        Console.WriteLine(string.Format(
            "PropertyChanged: {0} (from {1} to {2})", 
            propertyName, propertyOldValue, propertyNewValue));
    }
}
