namespace Task5LuckyTicket;

public static class LuckyTicket
{
    public static Int128 Count(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("n must be positive");
        }
        if (n % 2 == 1)
        {
            throw new ArgumentException("n must be an odd number");
        }
        var buffer = new Int128[n + 1, (n / 2) * 9 + 1];
        for (var i = 0; i < n + 1; i++)
        {
            for (var j = 0; j < (n / 2) * 9 + 1; j++)
            {
                buffer[i, j] = -1;
            }
        }
        return CountN(n, (n / 2) * 9, ref buffer);
    }
    
    private static Int128 CountN(int n, int k, ref Int128[,] buf)
    {
        if (k < 0 || k > 9 * n)
        {
            return 0;
        }
        if (n == 0) return Int128.Zero;
        if (n == 1)
        {
            return 1;
        }
        if (buf[n, k] >= 0)
        {
            return buf[n, k];
        }
        Int128 res =  CountN(n - 1, k - 9, ref buf) + CountN(n - 1, k - 8, ref buf) + CountN(n - 1, k - 7, ref buf) 
               + CountN(n - 1, k - 6, ref buf) + CountN(n - 1, k - 5, ref buf) + CountN(n - 1, k - 4, ref buf) 
               + CountN(n - 1, k - 3, ref buf) + CountN(n - 1, k - 2, ref buf) + CountN(n - 1, k - 1, ref buf) 
               + CountN(n - 1, k, ref buf);
        buf[n, k] = res;
        return res;
    }
}