public class Solution {
    public int NumTrees(int n) {
        double[] dp = new double[n+1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++) {
            dp[i] = ((2.0 * ((2 * i -1)) / (i + 1))) * dp[i-1];
        }
        return (int) dp[n];
    }
}