public delegate void VoidMethodHolder(int counter);
class AsyncTimer
{
    private VoidMethodHolder action;

    private int tickCounter;

    private int tickTimer;

    public AsyncTimer(int counter, int milliseconds, VoidMethodHolder method)
    {
        Counter = counter;
        Timer = milliseconds;
        action = method;
    }

    public int Counter
    {
        get { return this.tickCounter; }
        set
        {
            if (value < 2)
            {
                throw new System.ArgumentOutOfRangeException("counter",
                    "Counter cannot be a number lower than 2.");
            }
            this.tickCounter = value;
        }
    }

    public int Timer
    {
        get { return this.tickTimer; }
        set
        {
            if (value < 1000)
            {
                throw new System.ArgumentOutOfRangeException("timer",
                    "Timer value must be a number bigger or equal to 1000ms.");
            }
            this.tickTimer = value;
        }
    }

    public void ExecuteMethod()
    {
        System.Threading.Thread methodThread = new System.Threading.Thread(ExecutionEngine);
        methodThread.Start();
    }

    private void ExecutionEngine()
    {
        VoidMethodHolder method = this.action;
        for (int cnt = 0; cnt < this.Counter; cnt++)
        {
            System.Console.Write("Thread: {0} - ", System.Environment.CurrentManagedThreadId);
            method(cnt + 1);
            if (cnt != this.Counter - 1)
            {
                System.Threading.Thread.Sleep(this.tickTimer);
            }
        }
    }
}