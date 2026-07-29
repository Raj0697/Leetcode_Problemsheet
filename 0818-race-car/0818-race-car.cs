public class Solution {
    public int Racecar(int target) {
        int[] dp = new int[target + 1];
        return Dp(target, dp);
    }

    private int Dp(int target, int[] dp) {
        if (dp[target] > 0) return dp[target];
        int n = (int)Math.Log2(target) + 1; // Calculate the number of steps to overshoot or reach target
        if (1 << n == target + 1) {
            dp[target] = n; // Exact match with full acceleration
        } else {
            // Case 1: Go beyond the target and reverse
            dp[target] = n + 1 + Dp((1 << n) - 1 - target, dp); // Overshoot target and reverse
            
            // Case 2: Stop before the target, reverse and accelerate again
            for (int m = 0; m < n - 1; ++m) {
                dp[target] = Math.Min(dp[target], n + m + 1 + Dp(target - (1 << (n - 1)) + (1 << m), dp));
            }
        }
        return dp[target];
    }
}