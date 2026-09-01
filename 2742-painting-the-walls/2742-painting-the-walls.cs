using System;

public class Solution {
    public int PaintWalls(int[] cost, int[] time) {
        int n = cost.Length;
        int[] dp = new int[n + 1];
        
        // Initialize with a large value representing infinity.
        // 1e9 is safe because max total cost is 500 * 10^6 = 5 * 10^8.
        Array.Fill(dp, 1000000000); 
        dp[0] = 0;

        for (int i = 0; i < n; i++) {
            int c = cost[i];
            int wPushed = time[i] + 1; // Total walls covered by choosing this paid wall
            
            // Loop backwards to prevent using the same wall multiple times
            for (int w = n; w > 0; w--) {
                int remains = Math.Max(0, w - wPushed);
                dp[w] = Math.Min(dp[w], dp[remains] + c);
            }
        }
        
        return dp[n];
    }
}