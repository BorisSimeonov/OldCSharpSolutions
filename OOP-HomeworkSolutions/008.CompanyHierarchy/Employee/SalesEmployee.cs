using System;
using System.Collections.Generic;

class SalesEmployee : RegularEmployee, ISalesEmployee
{
    private List<Sale> salesField = new List<Sale>();

    public SalesEmployee(string firstName, string lastName, ulong id,
        string department, decimal salary, List<Sale> salesList)
        : base(firstName, lastName, id, department, salary)
    {
        Sales = salesList;
    }

    public List<Sale> Sales
    {
        get
        {
            return this.salesField;
        }

        set
        {
            if (value.Count > 0)
            {
                this.salesField = value;
            }
        }
    }

    public override string ToString()
    {
        string result = string.Format(
            "FullName: {0}\nId: {1}\nDepartment: {2}\nSalary: {3}\nSales: ",
            this.FirstName + " " + this.LastName, this.Id, this.Department,
            this.Salary);
        this.Sales.ForEach(item => result += 
        string.Format("\n\t{0}", item.ToString()));
        return result;
    }
}