namespace Task1;

public class Bear
{
    private readonly HoneyPot _honeyPot;

    public Bear(HoneyPot honeyPot)
    {
        _honeyPot = honeyPot;
    }

    public async Task WorkAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            _honeyPot.WaitForBear(token); 
            await _honeyPot.EatHoneyAsync(token);
        }
    }
}
