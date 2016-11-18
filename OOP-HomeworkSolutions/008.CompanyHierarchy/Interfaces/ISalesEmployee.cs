using System;
using System.Collections.Generic;

interface ISalesEmployee : IEmployee
{
    List<Sale> Sales { get; set; }
}