using System;

interface ICustomer : IPerson
{
    decimal PurchaseAmount { get; set; }
}