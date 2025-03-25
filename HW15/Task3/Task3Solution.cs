namespace Task3;

public class TaskSolution
{
    public static int MaxEnvelopes(int[][] envelopes)
    {
        if (envelopes == null || envelopes.Length == 0)
            return 0;

        var extendedEnvelopes = envelopes
            .SelectMany(e => new int[][] { new int[] { e[0], e[1] }, new int[] { e[1], e[0] } })
            .OrderBy(e => e[0]) 
            .ThenByDescending(e => e[1]) 
            .ToArray();

        int[] heights = extendedEnvelopes.Select(e => e[1]).ToArray();

        return LengthOfLIS(heights);
    }

    private static int LengthOfLIS(int[] nums)
    {
        int[] dp = new int[nums.Length];
        int len = 0;

        foreach (int num in nums)
        {
            int left = 0, right = len;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (dp[mid] < num)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            dp[left] = num;

            if (left == len)
            {
                len++;
            }
        }

        return len;
    }
}