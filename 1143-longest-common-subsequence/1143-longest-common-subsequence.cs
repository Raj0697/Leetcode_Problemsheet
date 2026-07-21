public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int m = text1.Length;
        int n = text2.Length;

        int[] dp = new int[n + 1];

        for (int i = 1; i <= m; i++) {
            int prev = 0;  // Initialize the value for the previous diagonal element

            for (int j = 1; j <= n; j++) {
                int temp = dp[j];  // Save the current value in dp[j] for the next iteration
                if (text1[i - 1] == text2[j - 1]) {
                    dp[j] = prev + 1;
                } else {
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                }
                prev = temp;  // Update prev for the next iteration
            }
        }

        return dp[n];
    }
}