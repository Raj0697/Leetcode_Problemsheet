public class Solution {
    public int SuperEggDrop(int k, int n) {
        int[][] dp = new int[k + 1][];
        for (int i = 0; i <= k; i++) {
            dp[i] = new int[n + 1];
        }

        int m = 0;
        while (dp[k][m] < n) {
            m++;
            for (int e = 1; e <= k; e++) {
                dp[e][m] = dp[e - 1][m - 1] + dp[e][m - 1] + 1;
            }
        }

        return m;
    }
}