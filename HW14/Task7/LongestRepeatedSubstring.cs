namespace Task7;
public static class LongestRepeatedSubstring
{
    public static string FindLongestRepeatedSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        int n = s.Length;
        int left = 1;
        int right = n;
        string result = string.Empty;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            string candidate = FindRepeatedSubstringOfLength(s, mid);

            if (candidate != null)
            {
                result = candidate;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    private static string FindRepeatedSubstringOfLength(string s, int length)
    {
        var seen = new HashSet<string>();
        for (int i = 0; i <= s.Length - length; i++)
        {
            string substring = s.Substring(i, length);
            if (seen.Contains(substring))
            {
                return substring;
            }
            seen.Add(substring);
        }

        return null;
    }
}