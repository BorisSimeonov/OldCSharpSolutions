using System;

public abstract class RegularEmployee : Employee, IEmployee
{
    public RegularEmployee(string firstName, string lastName, ulong id,
        string department, decimal salary)
        : base(firstName, lastName, id, department, salary)
    {

    }
}