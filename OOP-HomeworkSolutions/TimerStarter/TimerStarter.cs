using System;

class TimerStarter
{
    static void Main()
    {
        AsyncTimer firstTimer = new AsyncTimer(5, 1000, FirstTrigeredMetod);
        AsyncTimer secondTimer = new AsyncTimer(5, 2000, SecondTrigeredMetod);
        firstTimer.ExecuteMethod();
        secondTimer.ExecuteMethod();
        DateTime timeNow = DateTime.Now;
        while (timeNow.AddSeconds(10) > DateTime.Now)
        {
            System.Threading.Thread.Sleep(385);
            Console.WriteLine("\tMainThread: {1} - MainThreadWorking... {0}", 
                DateTime.Now - timeNow, System.Environment.CurrentManagedThreadId);
        }
        Console.WriteLine("Main method has ended.");
    }

    public static void FirstTrigeredMetod(int counter)
    {
        Console.WriteLine(
            "The first method executed for the {0} time.", counter);
    }

    public static void SecondTrigeredMetod(int counter)
    {
        Console.WriteLine(
            "The second method executed for the {0} time.", counter);
    }
}