namespace Task1;
    
internal class Program
{
    private static int counter = 0;
    private const int _totalThreadIterations = 100000;

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(IncrementCounter);
        Thread thread2 = new Thread(IncrementCounter);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
        
        Console.WriteLine($"Итоговое значение counter: {counter}");
    }

    static void IncrementCounter()
    {
        for (int i = 0; i < _totalThreadIterations; i++)
        {
            counter++;
        }
    }
}