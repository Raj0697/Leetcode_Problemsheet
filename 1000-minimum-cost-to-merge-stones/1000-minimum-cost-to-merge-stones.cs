public class Solution {
    public int MergeStones(int[] stones, int k) {
        int n = stones.Length;
        if ((n - 1) % (k - 1) != 0) return -1;
        int[,] dp = new int[n, n];
        int outerSum = 0;
        for (int i = 0; i < k - 1; i++) outerSum += stones[i];
        for (int y = k; y <= n; y++) {
            outerSum += stones[y - 1];
            int innerSum = dp[y - k, y - 1] = outerSum;
            outerSum -= stones[y - k];
            for (int x = y - k - 1; x >= 0; x--) {
                innerSum += stones[x];
                int p = (y - x - 2) % (k - 1) + 2;
                int minCost = int.MaxValue;
                for (int q = 1; q < p; q++) for (int z = x + q; z < y; z += k - 1) minCost = Math.Min(minCost, dp[x, z - 1] + dp[z, y - 1]);
                dp[x, y - 1] = (p == k ? innerSum : 0) + minCost;
            }
        }
        return dp[0, n - 1];
    }
}