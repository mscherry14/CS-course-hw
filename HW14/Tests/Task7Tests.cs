using Task7;

namespace Homework14.Tests;

[TestClass]
public class Task7Tests
{
    [TestMethod]
    public void TestFindLongestRepeatedSubstring_Example1()
    {
        string input = "mask4cask";
        string expected = "ask";
        string result = LongestRepeatedSubstring.FindLongestRepeatedSubstring(input);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestFindLongestRepeatedSubstring_Example2()
    {
        string input = "abcd";
        string expected = "";
        string result = LongestRepeatedSubstring.FindLongestRepeatedSubstring(input);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestFindLongestRepeatedSubstring_Example3()
    {
        string input = "banana";
        string expected = "ana";
        string result = LongestRepeatedSubstring.FindLongestRepeatedSubstring(input);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestFindLongestRepeatedSubstring_Example4()
    {
        string input = "aaaa";
        string expected = "aaa";
        string result = LongestRepeatedSubstring.FindLongestRepeatedSubstring(input);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestFindLongestRepeatedSubstring_Example5()
    {
        string input = "abcabc";
        string expected = "abc";
        string result = LongestRepeatedSubstring.FindLongestRepeatedSubstring(input);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestFindLongestRepeatedSubstring_EmptyString()
    {
        string input = "";
        string expected = "";
        string result = LongestRepeatedSubstring.FindLongestRepeatedSubstring(input);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestFindLongestRepeatedSubstring_NoRepeats()
    {
        string input = "abcdef";
        string expected = "";
        string result = LongestRepeatedSubstring.FindLongestRepeatedSubstring(input);
        Assert.AreEqual(expected, result);
    }
}
