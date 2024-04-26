public class Solution {
    public int MinFallingPathSum(int[][] grid) {
        int n = grid.Length, last = n-1;
        int[][] dp = new int[n][];
        dp[last] = new int[n];

        for(int i=last; i>=0; i--){
            dp[last][i] = grid[last][i];
        }

        for(int i=last-1; i>=0; i--){
            dp[i] = new int[n];
            Array.Fill(dp[i], 200000);
            int nextRow = i+1;
            int mini = -1, secondmini = -1;

            for(int j=0; j<n; j++){
                if(mini == -1 || dp[nextRow][j] < dp[nextRow][mini]){
                    secondmini = mini;
                    mini = j;
                }
                else if(secondmini == -1 || dp[nextRow][j] < dp[nextRow][secondmini]){
                    secondmini = j;
                }
            }

            for(int j=0; j<n; j++){
                if(j == mini){
                    dp[i][j] = dp[nextRow][secondmini] + grid[i][j];

                }
                else{
                    dp[i][j] = dp[nextRow][mini] + grid[i][j];
                }
            }
        }

        int res = int.MaxValue;

        for(int i=0; i<n; i++){
            res = Math.Min(dp[0][i], res);
        }

        return res;
    }
}