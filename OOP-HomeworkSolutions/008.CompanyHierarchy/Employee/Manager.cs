using System;
using System.Collections.Generic;
using System.Linq;

class Manager : Employee, IManager
{
    private List<RegularEmployee> employeeField = new List<RegularEmployee>();

    public Manager(string firstName, string lastName, ulong id,
        string department, decimal salary, List<RegularEmployee> employeeList)
        : base(firstName, lastName, id, department, salary)
    {
        this.EmployeeList = employeeList;   
    }

    public List<RegularEmployee> EmployeeList
    {
        get
        {
            return this.employeeField;
        }

        set
        {
            if (value != null)
            {
                if (value.Count > 0)
                {
                    this.employeeField = value;
                }
            }
            else
            {
                throw new ArgumentNullException("Employee list cannot be null.");
            }
        }
    }

    public override string ToString()
    {
        string result = string.Format(
           "FullName: {0}\nId: {1}\nDepartment: {2}\nSalary: {3}\nEmployees:",
           this.FirstName + " " + this.LastName, this.Id, this.Department, this.Salary);
        this.employeeField.OrderBy(item => item.LastName).OrderBy(item => item.FirstName).ToList().ForEach(item => result +=
        string.Format("\n\tName: {0}, ID: {1}, Department: {2}",item.FirstName + " " +
        item.LastName, item.Id, item.Department));
        return result;
    }
}