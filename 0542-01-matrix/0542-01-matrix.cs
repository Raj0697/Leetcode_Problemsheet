public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        int m = mat.Length;
        int n = mat[0].Length;
        
        int[][] result = new int[m][];
        for (int i = 0; i < m; i++) {
            result[i] = new int[n];
            for (int j = 0; j < n; j++) {
                result[i][j] = int.MaxValue - 1; // Initialize to a large value
                
                if (mat[i][j] == 0) {
                    result[i][j] = 0; // If it's 0, distance is 0
                }
                else {
                    // Check left and top neighbors
                    if (i > 0) result[i][j] = Math.Min(result[i][j], result[i - 1][j] + 1);
                    if (j > 0) result[i][j] = Math.Min(result[i][j], result[i][j - 1] + 1);
                }
            }
        }
        
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                // Check right and bottom neighbors
                if (i < m - 1) result[i][j] = Math.Min(result[i][j], result[i + 1][j] + 1);
                if (j < n - 1) result[i][j] = Math.Min(result[i][j], result[i][j + 1] + 1);
            }
        }
        
        return result;
    }
}