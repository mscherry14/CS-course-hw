namespace Task1;

public class Cache<T> : IDisposable where T : IDisposable
{
    private readonly int _maxSize;
    private readonly TimeSpan _expirationTime;
    private readonly Dictionary<string, CacheItem<T>> _cache = new Dictionary<string, CacheItem<T>>();
    private readonly object _lock = new object();
    private bool _disposed = false;
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public Cache(int maxSize, TimeSpan expirationTime)
    {
        _maxSize = maxSize;
        _expirationTime = expirationTime;
        RegisterForGCNotification();
    }

    public void Add(string key, T item)
    {
        lock (_lock)
        {
            if (_cache.Count >= _maxSize)
            {
                Cleanup();
            }

            if (!_cache.ContainsKey(key))
            {
                _cache[key] = new CacheItem<T>(key, item);
            }
            else
            {
                _cache[key].UpdateAccessTime();
            }
        }
    }

    public T Get(string key)
    {
        lock (_lock)
        {
            if (_cache.TryGetValue(key, out var cacheItem))
            {
                cacheItem.UpdateAccessTime();
                return cacheItem.Item;
            }
            return default;
        }
    }

    private void Cleanup()
    {
        var now = DateTime.UtcNow;
        var oldItems = _cache.Where(kvp => now - kvp.Value.LastAccessTime > _expirationTime).ToList();

        foreach (var item in oldItems)
        {
            item.Value.Dispose();
            _cache.Remove(item.Key);
        }

        if (_cache.Count >= _maxSize)
        {
            var oldest = _cache.OrderBy(kvp => kvp.Value.LastAccessTime).First();
            oldest.Value.Dispose();
            _cache.Remove(oldest.Key);
        }
    }

    private void RegisterForGCNotification()
    {
        GC.RegisterForFullGCNotification(10, 10); // Пороговые значения для Gen 0 и Gen 1

        var thread = new Thread(() =>
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
                {
                    lock (_lock)
                    {
                        Cleanup();
                    }
                }

                Thread.Sleep(100);
            }
        });

        thread.IsBackground = true; 
        thread.Start();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _cancellationTokenSource.Cancel();

                foreach (var item in _cache.Values)
                {
                    item.Dispose();
                }
                _cache.Clear();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Cache()
    {
        Dispose(false);
    }
}
