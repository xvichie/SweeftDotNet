class Program
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(1);
    static Random random = new Random();

    static async Task LogZerosAndOnes()
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

    static async Task LogNeoMessage()
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
        var logZerosAndOnes = LogZerosAndOnes();
        var logNeoMessage = LogNeoMessage();

        await Task.WhenAll(logZerosAndOnes, logNeoMessage);
    }
}
