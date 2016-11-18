using System;

public class Sale
{
    private string nameField;

    private DateTime saleDateField;

    private decimal priceField;

    public Sale(string name, DateTime date, decimal price)
    {
        this.Name = name;
        this.Date = date;
        this.Price = price;
    }

    public string Name
    {
        get { return this.nameField; }
        set
        {
            if (value != null)
            {
                if (value.Trim().Length > 2)
                {
                    this.nameField = value.Trim();
                }
                else
                {
                    throw new FormatException("Name length must be greater than 2");
                }
            }
            else
            {
                throw new ArgumentNullException("Name cannot be null.");
            }
        }
    }

    public decimal Price
    {
        get { return this.priceField; }
        set
        {
            if (value > 0m)
            {
                this.priceField = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    "Price cannot be null or negative number.");
            }
        }
    }

    public DateTime Date
    {
        get { return this.saleDateField; }
        set
        {
            if (value <= DateTime.Now)
            {
                saleDateField = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    "Date cannot surpass current datetime.");
            }
        }
    }

    public override string ToString()
    {
        string result = string.Format(
            "{0}, {1:f2}, {2}", this.Name, this.Price, 
            this.Date.ToString("dd/MM/yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
        return result;
    }
}
