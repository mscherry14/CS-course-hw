namespace Task1;

public class CacheItem<T> : IDisposable where T : IDisposable
{
    private bool _disposed = false;

    public string Key { get; }

    public T Item { get; }

    public DateTime LastAccessTime { get; private set; }

    public CacheItem(string key, T item)
    {
        Key = key;
        Item = item;
        UpdateAccessTime();
    }

    public void UpdateAccessTime()
    {
        LastAccessTime = DateTime.UtcNow;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Item.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~CacheItem()
    {
        Dispose(false);
    }
}