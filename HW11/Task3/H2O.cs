namespace Task3;

public class H2O
{
    private SemaphoreSlim hydrogenSemaphore = new SemaphoreSlim(2, 2);
    private SemaphoreSlim oxygenSemaphore = new SemaphoreSlim(1, 1);
    private Barrier barrier = new Barrier(3);

    public H2O()
    {
    }

    public void Hydrogen(Action releaseHydrogen)
    {
        hydrogenSemaphore.Wait();
        barrier.SignalAndWait();
        releaseHydrogen();
        hydrogenSemaphore.Release();
    }

    public void Oxygen(Action releaseOxygen)
    {
        oxygenSemaphore.Wait();
        barrier.SignalAndWait();
        releaseOxygen();
        oxygenSemaphore.Release();
    }
}