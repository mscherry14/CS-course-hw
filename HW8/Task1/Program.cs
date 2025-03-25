namespace Task1
{
    internal class Program
    {
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Запуск программы...");

            // Первый поток
            Thread thread1 = new Thread(() =>
            {
                Console.WriteLine("Поток 1: Захват lock1...");
                lock (lock1)
                {
                    Console.WriteLine("Поток 1: Захвачен lock1. Ожидание lock2...");

                    // Имитация работы
                    Thread.Sleep(100);

                    Console.WriteLine("Поток 1: Попытка захвата lock2...");
                    lock (lock2)
                    {
                        Console.WriteLine("Поток 1: Захвачен lock2.");
                    }
                }
            });

            // Второй поток
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Поток 2: Захват lock2...");
                lock (lock2)
                {
                    Console.WriteLine("Поток 2: Захвачен lock2. Ожидание lock1...");

                    // Имитация работы
                    Thread.Sleep(100);

                    Console.WriteLine("Поток 2: Попытка захвата lock1...");
                    lock (lock1)
                    {
                        Console.WriteLine("Поток 2: Захвачен lock1.");
                    }
                }
            });

            // Запуск потоков
            thread1.Start();
            thread2.Start();

            // Ожидание завершения потоков
            thread1.Join();
            thread2.Join();

            Console.WriteLine("Программа завершена.");
        }
    }
}