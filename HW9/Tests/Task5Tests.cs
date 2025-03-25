using Task3;
using Task5;

namespace Tests;

[TestClass]
public class Task5Tests
{
    [TestMethod]
    public void TestWait_Success()
    {
        using (var countdown = new CMyCountdownEvent(2))
        {
            new Thread(() =>
            {
                Thread.Sleep(100);
                countdown.Signal();
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(200);
                countdown.Signal();
            }).Start();

            Assert.IsTrue(countdown.Wait(TimeSpan.FromSeconds(1)));
        }
    }

    [TestMethod]
    public void TestWait_Timeout()
    {
        using (var countdown = new CMyCountdownEvent(2))
        {
            new Thread(() =>
            {
                Thread.Sleep(100);
                countdown.Signal();
            }).Start();

            Assert.IsFalse(countdown.Wait(TimeSpan.FromMilliseconds(50)));
        }
    }

    [TestMethod]
    public void TestSignal_ThrowsWhenCountReachesZero()
    {
        using (var countdown = new CMyCountdownEvent(1))
        {
            countdown.Signal();
            Assert.ThrowsException<InvalidOperationException>(() => countdown.Signal());
        }
    }

    [TestMethod]
    public void TestSignal_ThrowsWhenSignalCountExceedsRemaining()
    {
        using (var countdown = new CMyCountdownEvent(2))
        {
            Assert.ThrowsException<InvalidOperationException>(() => countdown.Signal(3));
        }
    }
}
