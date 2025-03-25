namespace Task2;

public static class Program
{
    public static string Permutations(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var permutations = GeneratePermutations(input);

        return string.Join(" ", permutations);
    }

    private static List<string> GeneratePermutations(string input)
    {
        var result = new List<string>();
        var stack = new Stack<(string, string)>();

        stack.Push(("", input));

        while (stack.Count > 0)
        {
            var (current, remaining) = stack.Pop();

            if (remaining.Length == 0)
            {
                result.Add(current);
                continue;
            }

            for (int i = 0; i < remaining.Length; i++)
            {
                var nextChar = remaining[i];
                var newRemaining = remaining.Substring(0, i) + remaining.Substring(i + 1);
                stack.Push((current + nextChar, newRemaining));
            }
        }

        return result;
    }

    public static void Main()
    {
        Console.WriteLine(Permutations("AB"));
        Console.WriteLine(Permutations("CD"));
        Console.WriteLine(Permutations("EF"));
        Console.WriteLine(Permutations("NOT"));
        Console.WriteLine(Permutations("RAM"));
        Console.WriteLine(Permutations("YAW"));
    }
}