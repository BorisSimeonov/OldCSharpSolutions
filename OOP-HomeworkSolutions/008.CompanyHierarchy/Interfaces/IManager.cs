using System.Collections.Generic;

interface IManager : IEmployee
{
    List<RegularEmployee> EmployeeList { get; set; }
}