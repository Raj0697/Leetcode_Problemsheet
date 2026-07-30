public class Solution
{
    int n, m;
    
    bool Solve(int x, int y, int open, char[][] grid, int[,,] dp)
    {
        if (x >= n || y >= m) return false;
        
        // Update the open parentheses count based on the current cell
        if (grid[x][y] == '(')
            open++;
        else
            open--;
        
        // If the number of closing parentheses exceeds opening ones, it's invalid
        if (open < 0)
            return false;

        // If we already computed the result for this state, return it
        if (dp[x, y, open] != -1)
            return dp[x, y, open] == 1;

        // If we've reached the bottom-right corner, check if the path is valid
        if (x == n - 1 && y == m - 1)
        {
            return open == 0;
        }

        // Recursively explore moving right or down
        bool ans = Solve(x + 1, y, open, grid, dp) || Solve(x, y + 1, open, grid, dp);

        // Memoize the result for this state
        dp[x, y, open] = ans ? 1 : 0;

        return ans;
    }

    public bool HasValidPath(char[][] grid)
    {
        n = grid.Length;
        m = grid[0].Length;

        // Initialize the DP array to store computed results
        int[,,] dp = new int[n, m, 201]; // dp dimensions: [x, y, open]
        
        // Fill the DP array with -1 to indicate unvisited states
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                for (int k = 0; k < 201; k++)
                    dp[i, j, k] = -1;

        // Start solving from the top-left corner (0, 0) with 0 open parentheses
        return Solve(0, 0, 0, grid, dp);
    }
}