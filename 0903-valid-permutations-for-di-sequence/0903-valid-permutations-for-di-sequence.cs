public class Solution {
    public int NumPermsDISequence(string s) {
        int n = s.Length;
        int MOD = 1000000007;
        int[,] dp = new int[n + 1, n + 1];
        dp[0, 0] = 1;

        for (int i = 1; i <= n; i++) {
            if (s[i - 1] == 'I') {
                int prefix = 0;
                // j ranges 0..i (i+1 choices)
                for (int j = 0; j <= i; j++) {
                    // sum dp[i-1][0..j-1]
                    if (j - 1 >= 0) prefix = (prefix + dp[i - 1, j - 1]) % MOD;
                    dp[i, j] = prefix;
                }
            } else { // 'D'
                int suffix = 0;
                // compute from right to left: j = i..0
                for (int j = i; j >= 0; j--) {
                    // sum dp[i-1][j..i-1]
                    if (j <= i - 1) suffix = (suffix + dp[i - 1, j]) % MOD;
                    dp[i, j] = suffix;
                }
            }
        }

        long ans = 0;
        for (int j = 0; j <= n; j++) {
            ans = (ans + dp[n, j]) % MOD;
        }
        return (int)ans;
    }
}