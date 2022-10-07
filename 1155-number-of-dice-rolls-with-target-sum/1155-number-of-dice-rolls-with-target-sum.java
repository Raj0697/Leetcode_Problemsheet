class Solution {
    public int numRollsToTarget(int n, int k, int target) {
        int m = 1000000000 + 7;
    int[][] dp = new int[n][target + 1]; 
    
    //base case
    for(int i = 1; i <= k && i <= target; i ++ )
        dp[0][i] = 1;
    
    //relation
    for(int i = 1; i < n; i ++ ){
        for(int j = i + 1; j <= k * (i + 1) && j <= target; j ++ ){
            //dp[i][j] = sum(dp[i][j - 1...k])
            for(int cur = 1; cur <= k && cur <= j; cur ++ ){
                dp[i][j] = (dp[i][j] + dp[i - 1][j - cur] ) % m;
            }
            
        }
    }
    
    
    return dp[n - 1][target];

    }
}