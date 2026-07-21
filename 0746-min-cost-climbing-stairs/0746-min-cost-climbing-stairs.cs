public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        int[] dp= new int[n+1];
        
        for(int i=2;i<dp.Length;i++){
           dp[i] = Math.Min(dp[i-1]+cost[i-1], dp[i-2]+cost[i-2]);
        }
        return dp[n];
    }
}