public class Solution {
    private Dictionary<string,int> memo;
    public int MinPathSum(int[][] grid) {
        memo = new Dictionary<string,int>();
        return GetPathSum(grid, 0,0);
    }
    private int GetPathSum(int[][] grid, int row, int col) {
        if(memo.ContainsKey($"{row}#{col}")){
            return memo[$"{row}#{col}"]; 
        }
        if(row >= grid.Length || col >= grid[0].Length){
            return Int32.MaxValue;
        }
        if(row == grid.Length - 1 && col == grid[0].Length - 1){
            return grid[row][col];
        }
        else{
            int down = GetPathSum(grid,row+1,col);
            int left = GetPathSum(grid,row,col+1); 
            memo.Add($"{row}#{col}", grid[row][col] + Math.Min(down,left));
            return grid[row][col] + Math.Min(down,left);
        }
    }
}