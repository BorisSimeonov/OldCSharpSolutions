//Create an abstract class Animal holding name, age and gender.
//•	Create a hierarchy with classes Dog, Frog, Cat, Kitten and 
//    Tomcat.Dogs, frogs and cats are animals.Kittens are female 
//    cats and Tomcats are male cats.Define useful constructors and methods.
//•	Define an interface ISoundProducible which holds the method 
//    ProduceSound(). All animals should implement this interface. 
//    The ProduceSound() method should produce a specific sound depending 
//    on the animal invoking it(e.g.the dog should bark).
//•	Create an array of different kinds of animals and calculate 
//    the average age of each kind of animal using LINQ.

using System;
using System.Diagnostics;
using System.Linq;

class AnimalsMain
{
    static void Main()
    {
        Frog firstFrog = new Frog("Flappy", 5, "male");
        Console.WriteLine(firstFrog);
        firstFrog.prodiceSound("WazZZupp!?");
        firstFrog.prodiceSound();

        Animal[] animalArray = {
            new Frog("Flappy", 7, "male"),
            new Tomcat("Garfield", 10, "male"),
            new Kitten("Zelda", 3, "female"),
            new Dog("Sparky", 8, "male"),
            new Dog("Fluffy", 1, "male"),
            new Frog("Jumpy", 2, "female"),
            new Kitten("Simka", 4, "female")
        };

        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        //LINQ version 00.0001507 - exec. time
        int ageSum = (from instance in animalArray
                      select instance.Age).Sum();

        //lambda version - 00.0001725 - exec. time
        //int ageSum = animalArray.Sum(item => item.Age);

        //Console.WriteLine(sw.Elapsed);
        Console.WriteLine("The age sum is: " + ageSum);
    }
}