using Task5;

namespace Tests;

[TestClass]
public class Task5Test
{
    [TestMethod]
    public void Test_AllAtomsSignaled_Success()
    {
        // Arrange
        using var myWaitAll = new CMyWaitAll(3);

        // Act
        myWaitAll.SetAtomSignaled(0);
        myWaitAll.SetAtomSignaled(1);
        myWaitAll.SetAtomSignaled(2);

        // Assert
        bool result = myWaitAll.Wait(TimeSpan.FromSeconds(1));
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Test_Timeout_WaitReturnsFalse()
    {
        // Arrange
        using var myWaitAll = new CMyWaitAll(3);

        // Act
        myWaitAll.SetAtomSignaled(0);
        myWaitAll.SetAtomSignaled(1);

        // Assert
        bool result = myWaitAll.Wait(TimeSpan.FromSeconds(1));
        Assert.IsFalse(result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_InvalidAtomId_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        using var myWaitAll = new CMyWaitAll(3);

        // Act
        myWaitAll.SetAtomSignaled(5);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_NegativeAtomsNumber_ThrowsArgumentOutOfRangeException()
    {
        // Act
        var myWaitAll = new CMyWaitAll(-1);
    }

    [TestMethod]
    public void Test_ConcurrentSignaling_Success()
    {
        // Arrange
        using var myWaitAll = new CMyWaitAll(3);

        // Act
        var thread1 = new Thread(() => myWaitAll.SetAtomSignaled(0));
        var thread2 = new Thread(() => myWaitAll.SetAtomSignaled(1));
        var thread3 = new Thread(() => myWaitAll.SetAtomSignaled(2));

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();

        // Assert
        bool result = myWaitAll.Wait(TimeSpan.FromSeconds(1));
        Assert.IsTrue(result);
    }

    [TestMethod]
    [ExpectedException(typeof(ObjectDisposedException))]
    public void Test_Dispose_ReleasesResources()
    {
        // Arrange
        var myWaitAll = new CMyWaitAll(3);

        // Act
        myWaitAll.Dispose();

        // Assert
        myWaitAll.SetAtomSignaled(0);
    }
}