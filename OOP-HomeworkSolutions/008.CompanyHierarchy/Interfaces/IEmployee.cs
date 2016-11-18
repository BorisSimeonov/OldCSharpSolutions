using System;

interface IEmployee : IPerson
{
    decimal Salary { get; set; }

    string Department { get; set; }
}