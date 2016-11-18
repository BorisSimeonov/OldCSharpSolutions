using System;

class Worker : Human
{
    private decimal weekSalary;

    private int workHoursPerDay;

    public Worker(string firstName, string lastName, 
        decimal weekSalary, int workHoursPerDay) 
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value > 0m)
            {
                this.weekSalary = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    "Salary must be decimal higher than zero.");
            }
        }
    }

    public int WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value > 0)
            {
                this.workHoursPerDay = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException
                    ("Hours per day must be a possitive integer value.");
            }
        }
    }

    public override string GetFullData()
    {
        return string.Format("Name: {0}\nWeekly Salary: {1} BGN\nWork Hours/Day: {2}",
            this.GetFullName(), Math.Round(this.WeekSalary, 2), this.WorkHoursPerDay);
    }

    public decimal MoneyPerHour()
    {
        decimal moneyPerHour;
        int workDaysInWeek = 5; //default for testing
        moneyPerHour = weekSalary / (this.workHoursPerDay * workDaysInWeek);
        return moneyPerHour;
            //string.Format("Money per hour: {0:f2} BGN", Math.Round(moneyPerHour, 3));
    }
}