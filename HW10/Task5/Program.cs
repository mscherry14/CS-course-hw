namespace Task5;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (var myWaitAll = new CMyWaitAll(5))
            {
                for (int i = 0; i < 5; i++)
                {
                    int atomId = i;
                    new Thread(() =>
                    {
                        Thread.Sleep(1000 * (atomId + 1));
                        Console.WriteLine($"Единица {atomId} сигнализирована.");
                        myWaitAll.SetAtomSignaled(atomId);
                    }).Start();
                }
                
                bool result = myWaitAll.Wait(TimeSpan.FromSeconds(10));
                Console.WriteLine(result ? "Все eдиницы сигнализированы." : "Тайм-аут ожидания.");
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
        }
    }
}
