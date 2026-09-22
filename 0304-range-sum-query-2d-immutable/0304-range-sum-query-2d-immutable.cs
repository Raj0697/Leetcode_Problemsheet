public class NumMatrix {
 private readonly int[][] ps;
    public NumMatrix(int[][] matrix) {
          int n = matrix.Length;
  if (n == 0) { ps = new int[0][]; return; }
  int m = matrix[0].Length;
  ps = new int[n][];
  for (int i = 0; i < n; i++)
  {
      ps[i] = new int[m + 1]; // ps[i][0] == 0
      for (int j = 0; j < m; j++)
      {
          ps[i][j + 1] = ps[i][j] + matrix[i][j];
      }
  }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
         int sum = 0;
 for (int r = row1; r <= row2; r++)
 {
     sum += ps[r][col2 + 1] - ps[r][col1];
 }
 return sum;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */