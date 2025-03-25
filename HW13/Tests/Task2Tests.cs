namespace Tests;

[TestClass]
public class Task2Tests
{
    [TestMethod]
    public void TestPermutations_AB()
    {
        string input = "AB";
        string[] expected = { "AB", "BA" };
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    [TestMethod]
    public void TestPermutations_CD()
    {
        string input = "CD";
        string[] expected = { "CD", "DC" };
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    [TestMethod]
    public void TestPermutations_EF()
    {
        string input = "EF";
        string[] expected = { "EF", "FE" };
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    [TestMethod]
    public void TestPermutations_NOT()
    {
        string input = "NOT";
        string[] expected = { "NOT", "NTO", "ONT", "OTN", "TNO", "TON" };
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    [TestMethod]
    public void TestPermutations_RAM()
    {
        string input = "RAM";
        string[] expected = { "AMR", "ARM", "MAR", "MRA", "RAM", "RMA" };
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    [TestMethod]
    public void TestPermutations_YAW()
    {
        string input = "YAW";
        string[] expected = { "AWY", "AYW", "WAY", "WYA", "YAW", "YWA" };
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    [TestMethod]
    public void TestPermutations_EmptyString()
    {
        string input = "";
        string[] expected = Array.Empty<string>();
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    [TestMethod]
    public void TestPermutations_SingleCharacter()
    {
        string input = "A";
        string[] expected = { "A" };
        string result = Task2.Program.Permutations(input);
        Assert.IsTrue(ArePermutationsEqual(expected, result));
    }

    private static bool ArePermutationsEqual(string[] expected, string result)
    {
        // Разбиваем результат на массив строк
        var resultArray = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Сортируем оба массива и сравниваем
        var sortedExpected = expected.OrderBy(s => s).ToArray();
        var sortedResult = resultArray.OrderBy(s => s).ToArray();

        return sortedExpected.SequenceEqual(sortedResult);
    }
}
