using Task3;

namespace Tests;

[TestClass]
public class Task3Tests
{
    [TestMethod]
    public void TestSingleNorthboundCar()
    {
        var bridge = new NarrowBridge();
        bridge.EnterFromNorth();
        bridge.ExitToNorth();
    }

    [TestMethod]
    public void TestSingleSouthboundCar()
    {
        var bridge = new NarrowBridge();
        bridge.EnterFromSouth();
        bridge.ExitToSouth();
    }

    [TestMethod]
    public void TestMultipleNorthboundCars()
    {
        var bridge = new NarrowBridge();
        bridge.EnterFromNorth();

        bool secondCarEntered = false;
        var thread = new Thread(() =>
        {
            bridge.EnterFromNorth();
            secondCarEntered = true;
            bridge.ExitToNorth();
        });
        thread.Start();

        Thread.Sleep(100);
        Assert.IsFalse(secondCarEntered); 

        bridge.ExitToNorth();
        Thread.Sleep(100);
        Assert.IsTrue(secondCarEntered);
    }

    [TestMethod]
    public void TestNorthboundAndSouthboundCars()
    {
        var bridge = new NarrowBridge();
        bridge.EnterFromNorth();

        bool southboundCarEntered = false;
        var thread = new Thread(() =>
        {
            bridge.EnterFromSouth();
            southboundCarEntered = true;
            bridge.ExitToSouth();
        });
        thread.Start();

        Thread.Sleep(100);
        Assert.IsFalse(southboundCarEntered);

        bridge.ExitToNorth();
        Thread.Sleep(100);
        Assert.IsTrue(southboundCarEntered);
    }
}
