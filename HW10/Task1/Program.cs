namespace Task1;

internal class Program
{
    static async Task Main(string[] args)
    {
        const int beeCount = 5;
        const int potCapacity = 10;

        var honeyPot = new HoneyPot(potCapacity);
        var bees = new List<Bee>();
        var bear = new Bear(honeyPot);

        for (int i = 0; i < beeCount; i++)
        {
            bees.Add(new Bee(honeyPot));
        }

        var cts = new CancellationTokenSource();

        var beeTasks = new List<Task>();
        foreach (var bee in bees)
        {
            beeTasks.Add(bee.WorkAsync(cts.Token));
        }

        var bearTask = bear.WorkAsync(cts.Token);

        await Task.Delay(10000);
        cts.Cancel();

        try
        {
            await Task.WhenAll(beeTasks);
            await bearTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Работа завершена по истечении времени.");
        }
    }
}
