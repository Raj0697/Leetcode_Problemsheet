public class Solution {
    const int MOD = 1000000007;

    public int CountPalindromicSubsequences(string s) {
        int n = s.Length;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = s[i] - 'a';

        int[,] next = new int[n, 4];
        int[,] prev = new int[n, 4];

        // init next with -1
        for (int i = 0; i < n; i++)
            for (int c = 0; c < 4; c++)
                next[i, c] = -1;

        // init prev with -1
        for (int i = 0; i < n; i++)
            for (int c = 0; c < 4; c++)
                prev[i, c] = -1;

        // build prev
        int[] last = new int[4];
        Array.Fill(last, -1);
        for (int i = 0; i < n; i++) {
            last[arr[i]] = i;
            for (int c = 0; c < 4; c++)
                prev[i, c] = last[c];
        }

        // build next
        Array.Fill(last, -1);
        for (int i = n - 1; i >= 0; i--) {
            last[arr[i]] = i;
            for (int c = 0; c < 4; c++)
                next[i, c] = last[c];
        }

        int[,] dp = new int[n, n];

        for (int len = 1; len <= n; len++) {
            for (int i = 0; i + len - 1 < n; i++) {
                int j = i + len - 1;

                long sum = 0;

                for (int c = 0; c < 4; c++) {
                    int L = next[i, c];
                    int R = prev[j, c];

                    if (L == -1 || L > j) continue;

                    if (L == R) {
                        sum += 1; // single char palindrome
                    } else if (L < R) {
                        sum += 2; // "c" and "cc"
                        if (L + 1 <= R - 1)
                            sum += dp[L + 1, R - 1];
                    }
                }

                dp[i, j] = (int)(sum % MOD);
            }
        }

        return dp[0, n - 1];
    }
}