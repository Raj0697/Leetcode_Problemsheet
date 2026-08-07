public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        int n = matrix.Length;

        for (int i = 1; i < n; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i][j] += Math.Min(matrix[i - 1][j],
                                  Math.Min((j > 0) ? matrix[i - 1][j - 1] : int.MaxValue,
                                           (j < n - 1) ? matrix[i - 1][j + 1] : int.MaxValue));
            }
        }

        return matrix[n - 1].Min();
    }
}