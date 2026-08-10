public class Solution {
    public int NumOfArrays(int n, int m, int k) {
        var z = 1000000007;
        var dp = new int[n + 1, m + 1, k + 1];

        dp[0, 0, 0] = 1;

        for (var i = 1; i <= n; ++i) {
            // to keep the max at j, i must choose a value <= j ===> l won't change
            for (var j = 0; j <= m; ++j) {
                for (var l = 0; l <= k; ++l) {
                    dp[i, j, l] += (int)((long)dp[i - 1, j, l] * j % z);
                    dp[i, j, l] %= z;
                }
            }

            // to update max to j, i must come from a place where max is j-1, j-2, etc. and must choose j
            for (var j = 0; j <= m; ++j) {
                for (var j2 = j - 1; j2 >= 0; --j2) {
                    for (var l = 1; l <= k; ++l) {
                        dp[i, j, l] += dp[i - 1, j2, l - 1];
                        dp[i, j, l] %= z;
                    }
                }
            }
        }

        var ans = 0;

        for (var j = 0; j <= m; ++j) {
            ans += dp[n, j, k];
            ans %= z;
        }

        return ans;
    }
}