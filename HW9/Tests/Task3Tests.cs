using Task3;

namespace Tests;

[TestClass]
public class Task3Tests
{
    [TestMethod]
    public void TestSort_SortsStringsByLength()
    {
        var sleepsort = new Sleepsort();
        string[] strings = { "apple", "banana", "kiwi", "orange", "grape" };
        
        sleepsort.Sort(strings);
        var sortedList = sleepsort.GetSortedList().ToList();
        
        Assert.AreEqual("kiwi", sortedList[0]);

        Assert.IsTrue(sortedList[1] == "apple" || sortedList[1] == "grape");
        Assert.IsTrue(sortedList[2] == "apple" || sortedList[2] == "grape");

        Assert.IsTrue(sortedList[3] == "orange" || sortedList[3] == "banana");
        Assert.IsTrue(sortedList[4] == "orange" || sortedList[4] == "banana");
    }

    [TestMethod]
    public void TestSort_EmptyArray()
    {
        var sleepsort = new Sleepsort();
        string[] strings = { };
        
        sleepsort.Sort(strings);
        var sortedList = sleepsort.GetSortedList().ToList();
        
        Assert.AreEqual(0, sortedList.Count);
    }

    [TestMethod]
    public void TestSort_SingleElement()
    {
        var sleepsort = new Sleepsort();
        string[] strings = { "apple" };
        
        sleepsort.Sort(strings);
        var sortedList = sleepsort.GetSortedList().ToList();
        
        Assert.AreEqual(1, sortedList.Count);
        Assert.AreEqual("apple", sortedList[0]);
    }

    [TestMethod]
    public void TestSort_StringsWithSameLength()
    {
        var sleepsort = new Sleepsort();
        string[] strings = { "apple", "grape", "mango" }; 
        
        sleepsort.Sort(strings);
        var sortedList = sleepsort.GetSortedList().ToList();
        
        Assert.AreEqual(3, sortedList.Count);
        Assert.IsTrue(sortedList.Contains("apple"));
        Assert.IsTrue(sortedList.Contains("grape"));
        Assert.IsTrue(sortedList.Contains("mango"));
    }
}