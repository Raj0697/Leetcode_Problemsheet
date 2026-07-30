public class Solution {
    public int CherryPickup(int[][] grid) {
        int n = grid.Length;
        int[,,] dp = new int[n, n, n];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    dp[i, j, k] = int.MinValue;
                }
            }
        }

        return Math.Max(0, Solve(0, 0, 0, grid, dp, n));
    }

    public int Solve(int r1,  int c1, int r2, int[][] grid, int[,,] dp, int n) {
        // As (r1 + c1 = r2 + c2)
        int c2 = r1 + c1 - r2;

        if (r1 >= n || c1 >= n || r2 >= n || c2 >= n) {
            return int.MinValue;
        }

        if (grid[r1][c1] == -1 || grid[r2][c2] == -1) {
            return int.MinValue;
        }

        if (r1 == n-1 && c1 == n-1) {
            return grid[r1][c1];
        }

        if (dp[r1, c1, r2] != int.MinValue) {
            return dp[r1, c1, r2];
        }

        int cherries = grid[r1][c1] + grid[r2][c2];
        if (r1 == r2 && c1 == c2) {
            cherries = grid[r1][c1];
        }

        int best = Math.Max(
            Math.Max(Solve(r1+1, c1, r2+1, grid, dp, n), Solve(r1, c1+1, r2, grid, dp, n)),
            Math.Max(Solve(r1+1, c1, r2, grid, dp, n), Solve(r1, c1+1, r2+1, grid, dp, n))
        );

        return dp[r1,c1,r2] = cherries + best;
    }
}