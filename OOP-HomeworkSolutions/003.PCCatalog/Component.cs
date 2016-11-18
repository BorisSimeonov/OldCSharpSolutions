using System;

class Component
{
    private string nameField;

    private string detailsField = null;

    private decimal priceField;

    public Component(string name, decimal price) : this(name, price, null)
    {

    }

    public Component(string name, decimal price, string details)
    {
        this.Name = name;
        this.Price = price;
        this.Details = details;
    }

    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            bool checker = false;
            if (value != null)
            {
                if (value.Length > 3 && value.Length < 25)
                {
                    checker = true;
                    this.nameField = value;
                }
            }
            if (!checker)
            {
                throw new FormatException(value == null ? "Comp. Name: Null Value" : 
                    "Comp. Name: Invalid text size.");
            }
        }
    }

    public decimal Price
    {
        get
        {
            return this.priceField;
        }
        set
        {
            if (value > 0 && value < 10000m)
            {
                this.priceField = value;
            }
        }
    }

    public string Details
    {
        get
        {
            return this.detailsField != null ? this.detailsField : "(no details)";
        }
        set
        {
            if (value != null)
            {
                if (value.Length > 5 && value.Length < 50)
                {
                    this.detailsField = value;
                }
                else
                {
                    throw new FormatException("Comp.Details: Invalid detail text size.");
                }
            }
            
        }
    }
}