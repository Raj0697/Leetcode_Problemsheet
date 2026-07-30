public class Solution {
    private int[] D; // Distances of the roads
    private long s, last; // Speed and last distance
    private long[,] memo; // Memoization table for DP

    // Recursive function to calculate minimum time with skips
    private long DfsWithSkips(int idx, int skip) {
        // Base case: if no more roads to process
        if (idx < 0) return 0;

        // Use memoization to avoid recomputation
        if (memo[idx, skip] != -1) return memo[idx, skip];

        // Start with the time if we don't skip
        long ret = DfsWithSkips(idx - 1, skip) + D[idx];

        // If we need to round up to the next hour
        if (ret % s != 0) ret = (ret + s) / s * s;

        // If we have skips available, consider skipping the rest
        if (skip > 0) {
            ret = Math.Min(ret, DfsWithSkips(idx - 1, skip - 1) + D[idx]);
        }

        // Store the result in the memo table
        memo[idx, skip] = ret;
        return ret;
    }

    public int MinSkips(int[] dist, int speed, int hoursBefore) {
        int n = dist.Length; // Number of roads
        D = dist; // Assign distances
        last = dist[n - 1]; // Last road distance
        s = speed; // Speed
        long H = hoursBefore * s; // Convert hoursBefore to the same unit as distance

        // Initialize memoization table with -1
        memo = new long[n, n + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= n; j++) {
                memo[i, j] = -1;
            }
        }

        // Fill the last row of the memo table
        for (int skip = n - 1; skip >= 0; skip--) {
            memo[n - 1, skip] = DfsWithSkips(n - 2, skip) + last;
        }

        // Check for the minimum skips required to meet the time constraint
        for (int i = 0; i < n; i++) {
            if (memo[n - 1, i] > 0 && memo[n - 1, i] <= H) return i;
        }

        return -1; // If not possible to arrive on time
    }
}