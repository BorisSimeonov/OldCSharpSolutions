using System;

class MainProgram
{
    public const int monthsPerYear = 12;

    static void Main()
    {
        //CalculateInterest del = GetSimpleInterest;
        //del += GetCompoundInterest;
        //del(2500m, 7.2m, 15);
        //del(500m, 5.6m, 10);

        InterestCalculator firstCalc = new InterestCalculator(
            2500m, 7.2m, 15, GetSimpleInterest);
        InterestCalculator secondCalc = new InterestCalculator(
            500m, 5.6m, 10, GetCompoundInterest);

        Console.WriteLine(firstCalc.ReturnBalance());
        Console.WriteLine(firstCalc);

        Console.WriteLine(secondCalc.ReturnBalance());
        Console.WriteLine(secondCalc);
    }

    public static decimal GetSimpleInterest(decimal money, decimal interest, int years)
    {
        decimal result = money * (1 + (interest/100 * years));
        return result;
    }

    public static decimal GetCompoundInterest(decimal money, decimal interest, int years)
    {
        decimal baseValue = 1 + ((interest/100) / monthsPerYear);
        int power = monthsPerYear * years;
        decimal result = 1;

        for (int cnt = 0; cnt < power; cnt++)
        {
            result *= baseValue;
        }

        result *= money;

        return result;
    }
}