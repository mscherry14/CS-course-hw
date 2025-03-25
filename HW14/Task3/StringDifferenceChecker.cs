namespace Task3;

public static class StringDifferenceChecker
{
    public static bool IsOneEditAway(string s1, string s2)
    {
        if (Math.Abs(s1.Length - s2.Length) > 1)
            return false;

        string shorter = s1.Length < s2.Length ? s1 : s2;
        string longer = s1.Length < s2.Length ? s2 : s1;

        int indexShorter = 0;
        int indexLonger = 0;
        bool foundDifference = false;

        while (indexShorter < shorter.Length && indexLonger < longer.Length)
        {
            if (shorter[indexShorter] != longer[indexLonger])
            {
                if (foundDifference)
                    return false;

                foundDifference = true;

                if (shorter.Length == longer.Length)
                {
                    indexShorter++;
                }
            }
            else
            {
                indexShorter++;
            }

            indexLonger++;
        }

        return true;
    }
}