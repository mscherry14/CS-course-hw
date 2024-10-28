using Task6Rainwater;

namespace Test;

[TestClass]
public class Task6RainwaterTest
{
    [TestMethod]
    public void AscendingHeightsTest()
    {
        int[] height = [1, 2, 3, 5];
        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 0);
    }
    
    [TestMethod]
    public void DescendingHeightsTest()
    {
        int[] height = [6, 4, 3, 2, 1];

        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 0);
    }
    
    [TestMethod]
    public void NullHeightsTest()
    {
        int[] height = [0, 0, 0, 0, 0, 0,];
        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 0);
    }
    
    [TestMethod]
    public void NullSizeHeightsTest()
    {
        int[] height = [];
        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 0);
    }
    
    [TestMethod]
    public void SimpleRightHeightsTest()
    {
        int[] height = [1, 0, 5];
        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 1);
    }
    
    [TestMethod]
    public void SimpleLeftHeightsTest()
    {
        int[] height = [4, 0, 2];
        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 2);
    }
    
    [TestMethod]
    public void PublicFirstExampleTest()
    {
        int[] height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 6);
    }
    
    [TestMethod]
    public void PublicSecondExampleTest()
    {
        int[] height = [4, 2, 0, 3, 2, 5];
        int count = RainwaterCounter.Count(ref height);
        Assert.AreEqual(count, 9);
    }
}