using System;

public class Project
{
    private string projectNameField;

    private DateTime startDateField;

    private string detailField = "";

    private bool stateField; //open or close

    public Project(string name, DateTime startDate, string details, bool state)
    {
        this.Name = name;
        this.Date = startDate;
        this.Details = details;
        this.State = state;
    }

    public string Name
    {
        get { return this.projectNameField; }
        set
        {
            if (value != null)
            {
                if (value.Trim().Length > 5 &&
                    value.Trim().Length < 25)
                {
                    this.projectNameField = value.Trim();
                }
                else
                {
                    throw new FormatException("Project name length must be in range 5-25 characters.");
                }
            }
            else
            {
                throw new ArgumentNullException("Project name cannot be null.");
            }
        }
    }

    public DateTime Date
    {
        get { return this.startDateField; }
        set
        {
            if (value <= DateTime.Now)
            {
                startDateField = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    "Date cannot surpass current datetime.");
            }
        }
    }

    public string Details
    {
        get { return this.detailField; }
        set
        {
            if (value != null)
            {
                this.detailField = value.Trim();
            }
        }
    }

    public bool State
    {
        get { return this.stateField; }
        set
        {
            this.stateField = value;
        }
    }

    public void CloseProject()
    {
        this.State = false;
    }

    public override string ToString()
    {
        string result = string.Format("{0}, {1}, {2},", this.Name, this.Date.ToString("dd/MM/yyyy",
            System.Globalization.CultureInfo.InvariantCulture), this.Details);
        if (this.State == false)
        {
            result += "Closed";
        }
        else
        {
            result += "Opened";
        }
            return result;
    }
}