public class Solution {
        public long SellingWood(int m, int n, int[][] prices)
    {
        long[][] dp = new long[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new long[n + 1];
        }
        for (int i = 0; i < prices.Length; ++i)
        {
            dp[prices[i][0]][prices[i][1]] = prices[i][2];
        }
        for (int i = 1; i < dp.Length; ++i)
        {
            for (int j = 1; j < dp[i].Length; ++j)
            {
                int limit = j / 2 + 1;
                for (int z = 1; z < limit; z++)
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[i][z] + dp[i][j - z]);
                }
                limit = i / 2 + 1;
                for (int z = 1; z < limit; z++)
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[z][j] + dp[i - z][j]);
                }
            }
        }
        return dp[m][n];
    }
}