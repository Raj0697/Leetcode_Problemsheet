public class Solution {
    public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen) {
        int n = floor.Length;
        int[,] dp = new int[n + 1, numCarpets + 1];

        // Initialize the dp array
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= numCarpets; j++) {
                dp[i, j] = int.MaxValue / 2; 
            }
        }
        dp[0, 0] = 0;

        // Fill the dp array
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= numCarpets; j++) {
                if (j > 0 && i >= carpetLen) {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - carpetLen, j - 1]);
                }
                if (j > 0 && i < carpetLen) {
                    dp[i, j] = Math.Min(dp[i, j], dp[0, j - 1]);
                }
                dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j] + (floor[i - 1] == '1' ? 1 : 0));
            }
        }

        int minWhiteTiles = int.MaxValue;
        for (int j = 0; j <= numCarpets; j++) {
            minWhiteTiles = Math.Min(minWhiteTiles, dp[n, j]);
        }

        return minWhiteTiles;
    }
}