namespace Task1;

public class HoneyPot
{
    private readonly int _capacity;
    private int _currentAmount;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1); 
    private readonly ManualResetEventSlim _bearEvent = new ManualResetEventSlim(false); 

    public HoneyPot(int capacity)
    {
        _capacity = capacity;
        _currentAmount = 0;
    }

    public async Task AddHoneyAsync(CancellationToken token)
    {
        await _semaphore.WaitAsync(token);

        if (_currentAmount < _capacity)
        {
            _currentAmount++;
            Console.WriteLine($"Пчела добавила порцию меда. В горшке {_currentAmount}/{_capacity}.");

            if (_currentAmount == _capacity)
            {
                _bearEvent.Set(); 
            }
        }

        _semaphore.Release();
    }

    public async Task EatHoneyAsync(CancellationToken token)
    {
        await _semaphore.WaitAsync(token); 

        if (_currentAmount == _capacity)
        {
            Console.WriteLine("Медведь проснулся и съел весь мед.");
            _currentAmount = 0; 
            _bearEvent.Reset();
        }

        _semaphore.Release();
    }

    public void WaitForBear(CancellationToken token)
    {
        _bearEvent.Wait(token);
    }
}