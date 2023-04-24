public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        int[][] result = new int[numRows][];
        int i = 0;
        while(i < numRows) {
            result[i] = new int[i+1];
            result[i][0] = result[i][i] = 1;
            int j = 1;
            while (j < i) {
               result[i][j] = result[i-1][j-1] + result[i-1][j];
               j++;
            }
            i++;
        }
        return result;
    }
}