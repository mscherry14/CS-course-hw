namespace Task5;

internal class Program
{
    static void Main(string[] args)
    {
        // Пример 1: Базовое использование
        using (var countdown = new CMyCountdownEvent(3))
        {
            Console.WriteLine("Запуск потоков...");

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Поток 1 завершил работу.");
                countdown.Signal();
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Поток 2 завершил работу.");
                countdown.Signal();
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Поток 3 завершил работу.");
                countdown.Signal();
            }).Start();

            Console.WriteLine("Ожидание завершения всех потоков...");
            if (countdown.Wait(TimeSpan.FromSeconds(5)))
            {
                Console.WriteLine("Все потоки завершили работу.");
            }
            else
            {
                Console.WriteLine("Таймаут ожидания истек.");
            }
        }

        // Пример 2: Использование Signal(int)
        using (var countdown = new CMyCountdownEvent(5))
        {
            Console.WriteLine("Запуск потоков с Signal(int)...");

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Поток 1 завершил работу (Signal(2)).");
                countdown.Signal(2);
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Поток 2 завершил работу (Signal(3)).");
                countdown.Signal(3);
            }).Start();

            Console.WriteLine("Ожидание завершения всех потоков...");
            if (countdown.Wait(TimeSpan.FromSeconds(5)))
            {
                Console.WriteLine("Все потоки завершили работу.");
            }
            else
            {
                Console.WriteLine("Таймаут ожидания истек.");
            }
        }

        // Пример 3: Исключение при превышении счетчика
        try
        {
            using (var countdown = new CMyCountdownEvent(2))
            {
                Console.WriteLine("Попытка Signal(3) при счетчике 2...");
                countdown.Signal(3); // Вызовет исключение
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
