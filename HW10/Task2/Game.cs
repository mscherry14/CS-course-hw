namespace Task2
{
    public class Game
    {
        private const int N = 10; // Размер поля
        private readonly object _lock = new object(); 
        private readonly Random _random = new Random();
        private readonly List<Sheep> _sheepList = new List<Sheep>();
        private Wolf _wolf;

        public Game()
        {
            for (int i = 0; i < 3; i++)
            {
                _sheepList.Add(new Sheep(_random.Next(0, N), _random.Next(0, N)));
            }

            _wolf = new Wolf(_random.Next(0, N), _random.Next(0, N));
        }

        public void Start()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var sheepTasks = new List<Task>();
            foreach (var sheep in _sheepList)
            {
                sheepTasks.Add(Task.Run(() => SheepMove(sheep, token), token));
            }
            var wolfTask = Task.Run(() => WolfMove(token), token);

            Task.Delay(30000).Wait(); 
            cts.Cancel(); 

            try
            {
                Task.WaitAll(sheepTasks.ToArray());
                Task.WaitAll(wolfTask);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(string.Join(",", ex.InnerExceptions.Select(e => e.Message)));
            }

            Console.WriteLine("Игра завершена.");
        }


        private void SheepMove(Sheep sheep, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                lock (_lock)
                {
                    if (sheep.X == _wolf.X && sheep.Y == _wolf.Y)
                    {
                        Console.WriteLine($"Баран на ({sheep.X}, {sheep.Y}) съеден волком.");
                        _sheepList.Remove(sheep);
                        break;
                    }

                    var newSheepList = new List<Sheep>();

                    foreach (var otherSheep in _sheepList)
                    {
                        if (otherSheep != sheep && sheep.X == otherSheep.X && sheep.Y == otherSheep.Y)
                        {
                            Console.WriteLine($"Бараны на ({sheep.X}, {sheep.Y}) создали нового барана.");
                            newSheepList.Add(new Sheep(_random.Next(0, N), _random.Next(0, N)));
                        }
                    }

                    _sheepList.AddRange(newSheepList);

                    sheep.Move(_random, N);
                    Console.WriteLine($"Баран переместился на ({sheep.X}, {sheep.Y}).");
                }

                Thread.Sleep(_random.Next(500, 1000));
            }
        }

        private void WolfMove(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                lock (_lock)
                {
                    _wolf.Move(_random, N);
                    Console.WriteLine($"Волк переместился на ({_wolf.X}, {_wolf.Y}).");
                }

                Thread.Sleep(_random.Next(500, 1000));
            }
        }
    }

}
