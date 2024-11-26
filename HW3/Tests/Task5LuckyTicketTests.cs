using Task5LuckyTicket;

namespace Tests;

[TestClass]
public class Task5LuckyTicketTests
{
    [TestMethod]
    public void OddNumberTest()
    {
        Assert.ThrowsException<ArgumentException>(() => LuckyTicket.Count(3));
    }
    
    [TestMethod]
    public void NullNumberTest()
    {
        Assert.AreEqual(LuckyTicket.Count(0), 0);
    }
    
    [TestMethod]
    public void NegativeNumberTest()
    {
        Assert.ThrowsException<ArgumentException>(() => LuckyTicket.Count(-4));
    }
    
    [TestMethod]
    public void ResultForTwoTest()
    {
        Assert.AreEqual(LuckyTicket.Count(2), 10);
    }

    [TestMethod]
    public void ResultForTwelveTest()
    {
        Assert.AreEqual(LuckyTicket.Count(12), 39581170420);
    }
}