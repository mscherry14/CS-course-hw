namespace Task5;

public static class Task5Solution
{
    public static List<string> Bucketize(string phrase, int n)
    {
        phrase = phrase.Trim();

        var words = phrase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (words.Any(word => word.Length > n))
        {
            return new List<string>();
        }

        var buckets = words
            .Aggregate(new List<(List<string> Bucket, int Length)>(), (acc, word) =>
            {
                if (acc.Count == 0 || acc.Last().Length + word.Length + acc.Last().Bucket.Count > n)
                {
                    acc.Add((new List<string> { word }, word.Length));
                }
                else
                {
                    var lastBucket = acc.Last().Bucket.ToList();
                    lastBucket.Add(word);
                    var lastLength = acc.Last().Length + word.Length;
                    acc[acc.Count - 1] = (lastBucket, lastLength);
                }
                return acc;
            })
            .Select(bucket => string.Join(" ", bucket.Bucket))
            .ToList();

        return buckets;
    }
}