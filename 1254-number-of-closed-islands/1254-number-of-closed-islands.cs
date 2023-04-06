public class Solution {
    int row;
    int col;
    public int ClosedIsland(int[][] grid)
    {
        int count = 0;
        row = grid.Length;
        if (row == 0) return 0;
        col = grid[0].Length;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (grid[i][j] == 0 && Dfs(grid, i, j)) count++;
            }
        }
        return count;
    }

    public bool Dfs(int[][] grid, int i, int j)
    {
        if (i < 0 || i >= row || j < 0 || j >= col || grid[i][j] == 1) return true;
        if (i == 0 || i == row - 1 || j == 0 || j == col - 1) return false;
        grid[i][j] = 1;
        return Dfs(grid, i + 1, j) &
               Dfs(grid, i, j - 1) &
               Dfs(grid, i - 1, j) &
               Dfs(grid, i, j + 1);
    }
}