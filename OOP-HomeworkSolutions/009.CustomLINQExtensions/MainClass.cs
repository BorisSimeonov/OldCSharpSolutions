using System;
using System.Collections.Generic;

class MainClass
{
    static void Main()
    {
        //predicate functions
        Func<double, bool> doublePredicate = x => x < 190d;
        Func<int, bool> intPredicate = x => x % 2 != 0;
        //--------------
        List<int> numbers = new List<int>() {
            1, 23, 442, 35, 676, 345, 212, 1 };
        Queue<double> queue = new Queue<double>();
        Random rnd = new Random();
        for (int x = 0; x < 5; x++) { queue.Enqueue((rnd.Next(1000)) / 3.14); }
        var students = new List<Student>()
        {
            new Student("Ivan", 4),
            new Student("Ivan", 3),
            new Student("Ivan", 9),
            new Student("Ivan", 1)
        };

        //--------------
        Console.WriteLine(string.Join(", ", numbers.WhereNot(intPredicate)));
        Console.WriteLine(string.Join(", ", queue.WhereNot(doublePredicate)));
        Console.WriteLine(students.MaxValue(st => st.Grade));
        Console.WriteLine(students.MinValue(st => st.Grade));
    }
}