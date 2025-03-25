using Task1;

namespace Tests;

[TestClass]
public class Task1Tests
{ 
    public class DisposableResource : IDisposable
    {
        public bool IsDisposed { get; private set; } = false;

        public void Dispose()
        {
            IsDisposed = true;
        }
    }

    [TestMethod]
    public void TestCleanupOnGCNotification()
    {
        var cache = new Cache<DisposableResource>(maxSize: 3, expirationTime: TimeSpan.FromMilliseconds(900));

        var resource1 = new DisposableResource();
        var resource2 = new DisposableResource();
        var resource3 = new DisposableResource();

        cache.Add("item1", resource1);
        cache.Add("item2", resource2);
        cache.Add("item3", resource3);

        Thread.Sleep(1000);
        
        string badSting = string.Empty;
        for (int i = 0; i < 100000; i++)
        {
            badSting += "*";
        }
        
        GC.Collect(2, GCCollectionMode.Forced);

        Thread.Sleep(3000);

        var retrieved1 = cache.Get("item1");
        var retrieved2 = cache.Get("item2");
        var retrieved3 = cache.Get("item3");

        Assert.IsNull(retrieved1);
        Assert.IsNull(retrieved2);
        Assert.IsNull(retrieved3);
    }

    [TestMethod]
    public void TestAddAndGet()
    {
        var cache = new Cache<DisposableResource>(maxSize: 2, expirationTime: TimeSpan.FromSeconds(10));

        var resource1 = new DisposableResource();
        var resource2 = new DisposableResource();

        cache.Add("item1", resource1);
        cache.Add("item2", resource2);

        var retrieved1 = cache.Get("item1");
        var retrieved2 = cache.Get("item2");

        Assert.IsNotNull(retrieved1);
        Assert.IsNotNull(retrieved2);
        Assert.AreEqual(resource1, retrieved1);
        Assert.AreEqual(resource2, retrieved2);
    }

    [TestMethod]
    public void TestCleanupBySize()
    {
        var cache = new Cache<DisposableResource>(maxSize: 2, expirationTime: TimeSpan.FromSeconds(10));

        var resource1 = new DisposableResource();
        var resource2 = new DisposableResource();
        var resource3 = new DisposableResource();

        cache.Add("item1", resource1);
        cache.Add("item2", resource2);
        cache.Add("item3", resource3);

        var retrieved1 = cache.Get("item1");
        var retrieved2 = cache.Get("item2");
        var retrieved3 = cache.Get("item3");

        Assert.IsNull(retrieved1);
        Assert.IsNotNull(retrieved2);
        Assert.IsNotNull(retrieved3);
    }

    [TestMethod]
    public void TestCleanupByAdd()
    {
        var cache = new Cache<DisposableResource>(maxSize: 2, expirationTime: TimeSpan.FromSeconds(1));

        var resource1 = new DisposableResource();
        var resource2 = new DisposableResource();
        var resource3 = new DisposableResource();

        cache.Add("item1", resource1);
        cache.Add("item2", resource2);

        Thread.Sleep(1500);

        cache.Add("item3", resource3);

        var retrieved1 = cache.Get("item1");
        var retrieved2 = cache.Get("item2");

        Assert.IsNull(retrieved1);
        Assert.IsNull(retrieved2);
    }

    [TestMethod]
    public void TestDispose()
    {
        var cache = new Cache<DisposableResource>(maxSize: 2, expirationTime: TimeSpan.FromSeconds(10));

        var resource1 = new DisposableResource();
        var resource2 = new DisposableResource();

        cache.Add("item1", resource1);
        cache.Add("item2", resource2);

        cache.Dispose();

        Assert.IsTrue(resource1.IsDisposed);
        Assert.IsTrue(resource2.IsDisposed);
    }

    [TestMethod]
    public void TestUpdateAccessTime()
    {
        var cache = new Cache<DisposableResource>(maxSize: 2, expirationTime: TimeSpan.FromSeconds(1));

        var resource1 = new DisposableResource();
        cache.Add("item1", resource1);

        Thread.Sleep(500);

        var retrieved1 = cache.Get("item1");
        Assert.IsNotNull(retrieved1);

        Thread.Sleep(600);

        var retrieved2 = cache.Get("item1");
        Assert.IsNotNull(retrieved2);
    }
}