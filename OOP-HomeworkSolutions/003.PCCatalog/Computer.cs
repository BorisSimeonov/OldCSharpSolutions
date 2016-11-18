using System;
using System.Collections.Generic;

class Computer
{
    private string nameField = null;

    private List<Component> componentsField = null;

    public Computer(string name, List<Component> components)
    {
        this.Name = name;
        this.Components = components;
    }

    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            bool isValid = false;
            if (value != null)
            {
                if (value.Trim().Length > 0 && value.Trim().Length < 25)
                {
                    this.nameField = value.Trim();
                    isValid = true;
                }
            }

            if (!isValid)
            {
                throw new FormatException(value == null ? "Name: Null Value Exception." :
                    "Name: Text Size Exception (>0 && <25 signs)");
            }
        }
    }

    public List<Component> Components
    {
        get
        {
            return this.componentsField;
        }
        set
        {
            if (value.Count > 0 && value != null)
            {
                this.componentsField = value;
            }
            else
            {
                throw new FormatException("Components: Empyu List of elements of type Component()");
            }
        }
    }

    public override string ToString()
    {
        decimal fullPrice = 0m;
        string result = "Current configuration:\n\n";
        result += this.nameField;

        componentsField.ForEach(compItem =>
        result += "\n\t" + string.Format(compItem.Details == null ?
        "{0}, {1}" : "{0}, {1}, {2}", compItem.Name, compItem.Price + " BGN", compItem.Details)
        );

        componentsField.ForEach(compItem => fullPrice += compItem.Price);

        result += "\n\tTotal Price: " + Math.Round(fullPrice, 2) + " BGN";
        return result;
    }

    //default return is in BGN
    public string GetFullPrice(decimal currencyModificator = 1, string sign = null)
    {
        decimal sum = 0m;
        componentsField.ForEach(element =>
        sum += element.Price);
        
        return Math.Round(sum/currencyModificator, 2) + 
            string.Format(sign == null ? " {0}" : " {1}", "BGN", sign);
    }
}