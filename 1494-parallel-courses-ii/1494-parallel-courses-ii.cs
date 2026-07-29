public class Solution {
    public int MinNumberOfSemesters(int n, int[][] relations, int k) {
        List<int> dp = new List<int>(new int[1 << n]);
        for (int i = 0; i<(1 << n); i++)
        {
            dp[i] = n;
        }
        List<int> pre = new List<int>(new int[n]);
        foreach (var x in relations) {
            --x[0];
            --x[1];
            pre[x[1]] |= 1 << x[0];
        }
        dp[0] = 0;
        for (int i = 0; i < (1 << n); i++) {
            int can = 0;
            for (int j = 0; j < n; j++) {
                if ((pre[j] & i) == pre[j]) {
                    can |= (1 << j);
                }
            }
            can &= ~i;
            for (int s = can; Convert.ToBoolean(s) ; s = ((s - 1) & can)) {
                if (System.Numerics.BitOperations.PopCount((uint)s) <= k) {
                    dp[i | s] = Math.Min(dp[i | s], dp[i] + 1);
                }
            }
        }
        return dp[(1 << n) - 1];
    }
}