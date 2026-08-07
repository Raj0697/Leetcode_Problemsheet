public class Solution {
    public int Change(int amount, int[] coins) {
         var dp = new int[amount + 1];
 dp[0] = 1;

 foreach (var coin in coins)
     for (int x = coin; x <= amount; x++)
         dp[x] += dp[x - coin];

 return dp[amount];
    }
}