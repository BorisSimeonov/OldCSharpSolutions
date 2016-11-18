using System;

class Frog : Animal
{
    public Frog(string name, int age, string gender)
        : base(name, age, gender)
    {
        
    }

    public override void prodiceSound(string sound = "Some frog sound.")
    {
        Console.WriteLine(sound);
    }
}