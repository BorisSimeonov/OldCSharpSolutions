using System;
using System.Collections.Generic;

class Developer : RegularEmployee, IDeveloper
{
    private List<Project> projectsField = new List<Project>();

    public Developer(string firstName, string lastName, ulong id,
        string department, decimal salary, List<Project> projectList)
        : base(firstName, lastName, id, department, salary)
    {
        this.Projects = projectList;
    }

    public List<Project> Projects
    {
        get
        {
            return this.projectsField;
        }

        set
        {
            if (value != null)
            {
                if (value.Count > 0)
                {
                    this.projectsField = value;
                }
            }
            else
            {
                throw new ArgumentNullException("Projects list cannot be null.");
            }
        }
    }

    public override string ToString()
    {
        string result = string.Format(
            "FullName: {0}\nId: {1}\nDepartment: {2}\nSalary: {3}\nProjects: ",
            this.FirstName + " " + this.LastName, this.Id, this.Department,
            this.Salary);
        this.Projects.ForEach(item => result +=
        string.Format("\n\t{0}", item.ToString()));
        return result;
    }
}