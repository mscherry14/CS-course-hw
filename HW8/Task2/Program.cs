namespace Task2
{
    internal class Program
    {
        private static SemaphoreSlim semaphoreT1 = new SemaphoreSlim(1, 1);
        private static SemaphoreSlim semaphoreT2 = new SemaphoreSlim(0, 1); 

        static void Main(string[] args)
        {
            Console.WriteLine("Запуск программы...");

            Thread thread1 = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    semaphoreT1.Wait();
                    Console.WriteLine($"Поток T1: Строка {i}");
                    semaphoreT2.Release();
                }
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    semaphoreT2.Wait();
                    Console.WriteLine($"Поток T2: Строка {i}");
                    semaphoreT1.Release();
                }
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Программа завершена.");
        }
    }
}