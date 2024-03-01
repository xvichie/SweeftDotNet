using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(1);
    static Random random = new Random();

    static async Task ContinuousLogging()
    {
        while (true)
        {
            await semaphore.WaitAsync();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(random.Next(0, 2)); 
            Console.ResetColor(); 
            semaphore.Release();
            await Task.Delay(10); 
        }
    }

    static async Task TimedLogging()
    {
        while (true)
        {
            await Task.Delay(5000);
            Console.WriteLine();
            await semaphore.WaitAsync();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Neo, you are the chosen one!");
            await Task.Delay(5000);
            semaphore.Release();

        }
    }

    static async Task Main(string[] args)
    {
        var continuousLoggingTask = ContinuousLogging();
        var timedLoggingTask = TimedLogging();

        await Task.WhenAll(continuousLoggingTask, timedLoggingTask);
    }
}
