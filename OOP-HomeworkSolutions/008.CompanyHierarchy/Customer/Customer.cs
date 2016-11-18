using System;

class Customer : Person, ICustomer
{
    private decimal purchaseField;

    public Customer(string firstName, string lastName, ulong id,
        decimal purchaseAmount) : base(firstName, lastName, id)
    {
        this.PurchaseAmount = purchaseAmount;
    }

    public decimal PurchaseAmount
    {
        get
        {
            return this.purchaseField;
        }

        set
        {
            if (value >= 0m)
            {
                this.purchaseField = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    "Purchase price cannot be a negative decimal number");
            }
        }
    }

    public override string ToString()
    {
        string result = string.Format(
            "Full Name: {0}\nId: {1}\nPurchasedAmount: {2:f2}",
            this.FirstName + " " + this.LastName, this.Id, this.PurchaseAmount);
        return result;
    }
}