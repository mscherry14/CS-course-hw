using Task3;

namespace Homework14.Tests;

[TestClass]
public class Task3Tests
{
    [TestMethod]
    public void TestOneEditAway_Remove()
    {
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("pale", "ple"));
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("pales", "pale"));
    }

    [TestMethod]
    public void TestOneEditAway_Replace()
    {
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("pale", "bale"));
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("pale", "palo"));
    }

    [TestMethod]
    public void TestOneEditAway_Add()
    {
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("pale", "paleo"));
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("ple", "pale"));
    }

    [TestMethod]
    public void TestOneEditAway_NoChanges()
    {
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("pale", "pale"));
    }

    [TestMethod]
    public void TestOneEditAway_MoreThanOneEdit()
    {
        Assert.IsFalse(StringDifferenceChecker.IsOneEditAway("pale", "bake"));
        Assert.IsFalse(StringDifferenceChecker.IsOneEditAway("pale", "pa"));
    }

    [TestMethod]
    public void TestOneEditAway_EmptyStrings()
    {
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("", ""));
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("a", ""));
        Assert.IsTrue(StringDifferenceChecker.IsOneEditAway("", "a"));
    }

    [TestMethod]
    public void TestOneEditAway_LargeDifference()
    {
        Assert.IsFalse(StringDifferenceChecker.IsOneEditAway("pale", "palestine"));
    }
}
