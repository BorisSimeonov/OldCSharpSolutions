using System;

class Dog : Animal
{
    public Dog(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override void prodiceSound(string sound = "Some dog sound.")
    {
        Console.WriteLine(sound);
    }
}