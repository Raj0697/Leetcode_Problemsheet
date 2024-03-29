public class Solution {
    public int ClimbStairs(int n) {
        //if(n <= 0)
        //    return 0;
        if(n == 1)
            return 1;
        if(n == 2)
            return 2; /*
        int total = 0, nminus1 = 2, nminus2 = 1;
        for(int i=2; i<n; i++) {
            total = nminus1 + nminus2;
            nminus2 = nminus1;
            nminus1 = total;
        }
        return total; */
        int[] dp = new int[n+1];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 2;
        for(int i=3; i<=n; i++) {
            dp[i] = dp[i-1] + dp[i-2];
        }
        return dp[n];
    }
}