using System;

public abstract class Employee : Person, IEmployee
{
    private decimal salaryField;

    private string departmentField;

    public Employee(string firstName, string lastName, ulong id,
        string department, decimal salary)
        : base(firstName, lastName, id)
    {
        this.Department = department;
        this.Salary = salary;
    }

    public string Department
    {
        get
        {
            return this.departmentField;
        }

        set
        {
            if (value != null)
            {
                if (value.Trim() == "Production" ||
                    value.Trim() == "Accounting" ||
                    value.Trim() == "Sales" ||
                    value.Trim() == "Marketing"
                    )
                {
                    this.departmentField = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Department can only be only: Production, Accounting, Sales or Marketing");
                }
            }
            else
            {
                throw new ArgumentNullException("Department name cannot be null.");
            }
        }
    }

    public decimal Salary
    {
        get
        {
            return this.salaryField;
        }

        set
        {
            if (value > 0m)
            {
                this.salaryField = value;
            }
            else
            {
                throw new IndexOutOfRangeException(
                    "Salary can only be positive decimal number.");
            }
        }
    }

    public abstract override string ToString();
}