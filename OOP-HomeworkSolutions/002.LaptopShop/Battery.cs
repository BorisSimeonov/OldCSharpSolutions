using System;

class Battery
{
    private string nameField = null;

    private double chargedUsageField = 0.0d;

    public Battery()
    {

    }

    public Battery(string name, double usageDuration)
    {
        this.Name = name;
        this.UsageDuration = usageDuration;
    }

    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            if (value != null)
            {
                if (value.Length > 5 &&
                    value.Length < 50)
                {
                    this.nameField = value.Trim();
                }
            }
        }
    }

    public double UsageDuration
    {
        get
        {
            return this.chargedUsageField;
        }
        set
        {
            if (value > 0d)
            {
                this.chargedUsageField = Math.Round(value, 1);
            }
        }
    }


}