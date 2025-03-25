namespace Task5
{
    internal class Program
    {
        private static volatile bool stopFlag = false;
        private static double piSum = 0.0;
        private static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество потоков:");
            int numThreads = int.Parse(Console.ReadLine());

            Console.WriteLine("Запуск вычисления числа Пи. Введите 'stop' для завершения.");

            Thread[] threads = new Thread[numThreads];

            for (var i = 0; i < numThreads; i++)
            {
                var i1 = i;
                threads[i] = new Thread(() => CalculatePi(i1, numThreads));
                threads[i].Start();
            }

            while (Console.ReadLine()?.ToLower() != "stop")
            {
                Console.WriteLine("Введите 'stop' для завершения.");
            }
            stopFlag = true;

            // Даем потокам время завершить текущую итерацию
            Thread.Sleep(10);

            // Ожидание завершения всех потоков
            for (int i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"Приближенное значение числа Пи: {piSum * 4}");
        }

        static void CalculatePi(int threadId, int numThreads)
        {
            double partialSum = 0.0;
            long iteration = 0;
            while (!stopFlag)
            {
                // Вычисление частичной суммы ряда Лейбница
                double term = 1.0 / (2 * iteration * numThreads + 2 * threadId + 1);
                if ((2 * iteration * numThreads + 2 * threadId + 1) % 4 == 1)
                {
                    partialSum += term;
                }
                else
                {
                    partialSum -= term;
                }
                iteration++;
                
                // Проверка флага остановки через каждые 1000000 итераций
                if (iteration % 1000000 == 0 && stopFlag)
                {
                    break;
                }
            }

            lock (lockObject)
            {
                piSum += partialSum;
            }
        }
    }
}
