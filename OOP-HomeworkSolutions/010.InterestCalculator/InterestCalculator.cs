using System;

public delegate decimal CalculateInterest(decimal money, decimal interest, int years);

public class InterestCalculator
{
    private decimal moneyAmount;

    private decimal interestProc;

    private int years;

    private readonly CalculateInterest caclulationMethod;

    public InterestCalculator(decimal money, decimal interest, int years, 
        CalculateInterest method)
    {
        Money = money;
        Interest = interest;
        Years = years;
        this.caclulationMethod = method;
    }

    public decimal Money
    {
        get { return this.moneyAmount; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("money",
                    "Money amount cannot be negative or zero.");
            }
            this.moneyAmount = value;
        }
    }

    public decimal Interest
    {
        get { return this.interestProc; }
        set
        {
            if (value <= 0m)
            {
                throw new ArgumentOutOfRangeException("interest", 
                    "Interest cannot be a negative number or zero");
            }
            this.interestProc = value;
        }
    }

    public int Years
    {
        get { return this.years; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("years", 
                    "The period cannot be less than 1 year");
            }

            this.years = value;
        }
    }

    public decimal ReturnBalance()
    {
        return Math.Round(this.caclulationMethod(
            this.Money, this.Interest, this.Years), 4);
    }

    public override string ToString()
    {
        return string.Format("Money: {0}, Interest: {1}, Years: {2}, Result: {3:F4}",
            this.Money, this.Interest, this.Years, this.ReturnBalance());
    }
}