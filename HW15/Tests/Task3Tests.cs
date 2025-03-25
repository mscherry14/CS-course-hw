using Task3;

namespace Homework15.Tests;

[TestClass]
public class Task3Tests
{
    [TestMethod]
    public void TestMaxEnvelopes_Example1()
    {
        int[][] envelopes =
        [
            [5, 4],
            [6, 4],
            [6, 7],
            [2, 3]
        ];
        int expected = 3;
        int result = TaskSolution.MaxEnvelopes(envelopes);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMaxEnvelopes_Example2()
    {
        int[][] envelopes =
        [
            [1, 1],
            [1, 1],
            [1, 1]
        ];
        int expected = 1;
        int result = TaskSolution.MaxEnvelopes(envelopes);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMaxEnvelopes_EmptyArray()
    {
        int[][] envelopes = Array.Empty<int[]>();
        int expected = 0;
        int result = TaskSolution.MaxEnvelopes(envelopes);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMaxEnvelopes_SingleEnvelope()
    {
        int[][] envelopes =
        [
            [2, 3]
        ];
        int expected = 1;
        int result = TaskSolution.MaxEnvelopes(envelopes);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMaxEnvelopes_AllNested()
    {
        int[][] envelopes =
        [
            [2, 3],
            [5, 4],
            [6, 7],
            [7, 8]
        ];
        int expected = 4;
        int result = TaskSolution.MaxEnvelopes(envelopes);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMaxEnvelopes_NoNestingPossible()
    {
        int[][] envelopes = new int[][]
        {
            [1, 1],
            [2, 2],
            [3, 1]
        };
        int expected = 2;
        int result = TaskSolution.MaxEnvelopes(envelopes);
        Assert.AreEqual(expected, result);
    }
}