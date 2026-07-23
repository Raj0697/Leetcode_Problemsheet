public class Solution {
    public int MaximalSquare(char[][] matrix) {
        // 1 extra row and col for padding default values
        int[,] dpGrid = new int[matrix.Length + 1, matrix[0].Length + 1];

        int max = 0;
        for(int i = 1; i <= matrix.Length; i++)
        {
            for(int j = 1; j <= matrix[0].Length; j++)
            {
                if(matrix[i - 1][j - 1] == '1')
                    dpGrid[i, j] = Math.Min(Math.Min(dpGrid[i - 1, j], dpGrid[i, j - 1]), dpGrid[i - 1, j- 1]) + 1;
                max = Math.Max(max, dpGrid[i, j]);
            }
        }

        return max*max; // return area
    }
}