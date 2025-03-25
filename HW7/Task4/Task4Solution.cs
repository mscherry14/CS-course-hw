namespace Task4;

public static class Task4Solution
{
    public static IEnumerable<string> CreateBook(string text, int wordsPerPage, Dictionary<string, string> dictionary)
    {
        var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var translatedWords = words.Select(word => dictionary[word.ToLower()].ToUpper());

        var pages = translatedWords
            .Select((word, index) => new { Word = word, Index = index })
            .GroupBy(x => x.Index / wordsPerPage)
            .Select(group => string.Join(" ", group.Select(x => x.Word)));

        return pages;
    }
}