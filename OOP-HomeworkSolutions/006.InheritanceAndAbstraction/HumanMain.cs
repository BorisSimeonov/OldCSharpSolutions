//Define an abstract class Human holding a first name and a last name.
//•	Define a class Student derived from Human that has a field faculty 
//    number(5-10 digits / letters).
//•	Define a class Worker derived from Human with fields WeekSalary and 
//    WorkHoursPerDay and method MoneyPerHour() that returns the payment 
//    earned by hour by the worker.
//•	Define the proper constructors and properties for the classes in 
//    your class hierarchy.
//•	Initialize a list of 10 students and sort them by faculty number 
//    in ascending order(use a LINQ query or the OrderBy() extension method). 
//    Initialize a list of 10 workers and sort them by payment per hour in 
//    descending order.
//•	Merge the lists and then sort them by first name and last name.

using System;
using System.Collections.Generic;
using System.Linq;

class HumanMain
{
    static void Main()
    {
        //Console.WriteLine(testStudent.GetFullData());
        //Console.WriteLine(testWorker.GetFullData());
        //Console.WriteLine(testWorker.MoneyPerHour());

        List<Worker> firstWorkerList = new List<Worker>();
        firstWorkerList.Add(new Worker("Petar", "Petrov", 540m, 7));
        firstWorkerList.Add(new Worker("Ivan", "Petrov", 1540m, 7));
        firstWorkerList.Add(new Worker("Georgi", "Iliev", 240m, 7));
        firstWorkerList.Add(new Worker("Todor", "Iliev", 340m, 7));
        firstWorkerList.Add(new Worker("Teodor", "Atanasov", 1220m, 7));
        firstWorkerList.Add(new Worker("Stavri", "Enev", 4330m, 7));
        firstWorkerList.Add(new Worker("Stelian", "Gerov", 1230m, 7));
        firstWorkerList.Add(new Worker("Martin", "Manolov", 820m, 7));
        firstWorkerList.Add(new Worker("Atanas", "Atanasov", 490m, 7));
        firstWorkerList.Add(new Worker("Atanas", "Ivankov", 910m, 7));
        firstWorkerList.Add(new Worker("Iliq", "Stavrev", 2540m, 7));

        List<Student> firstStudentList = new List<Student>();
        firstStudentList.Add(new Student("Ivan", "Petrov", "12237834"));
        firstStudentList.Add(new Student("Iliq", "Genov", "2312334"));
        firstStudentList.Add(new Student("Mihail", "Mitkov", "12314442"));
        firstStudentList.Add(new Student("Gero", "Berov", "4423223"));
        firstStudentList.Add(new Student("Aleks", "Stoilov", "2223344"));
        firstStudentList.Add(new Student("Asen", "Stelianov", "445346776"));
        firstStudentList.Add(new Student("Yuri", "Aleksov", "45645656"));
        firstStudentList.Add(new Student("Georgi", "Shterev", "8452342"));
        firstStudentList.Add(new Student("Simeon", "Tinkov", "12223454"));
        firstStudentList.Add(new Student("Yulian", "Qsenov", "9788689692"));
        
        firstWorkerList = firstWorkerList.OrderByDescending(e => e.MoneyPerHour()).ToList();
        firstStudentList = firstStudentList.OrderBy(e => long.Parse(e.FacultyNumber)).ToList();

        //firstWorkerList.ForEach(e => Console.WriteLine(e.GetFullName()));
        //firstStudentList.ForEach(e => Console.WriteLine(e.GetFullName()));

        List<Human> mixedList = new List<Human>();
        firstWorkerList.ForEach(e => mixedList.Add(e));
        firstStudentList.ForEach(e => mixedList.Add(e));

        mixedList = mixedList.OrderBy(e => e.GetFullName().ToLower()).ToList();
        mixedList.ForEach(e => Console.WriteLine(e.GetFullName()));
    }
}