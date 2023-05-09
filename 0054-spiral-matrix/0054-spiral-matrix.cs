public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        IList<int> result = new List<int>();
        
        int i = 0, j = 0;
        while(true){
            //check if all sides are visited
            if((j < n-1 && matrix[i][j+1] != 101) //instead of 101 we can make it int.MaxValue or int.MinValue
               || (i < m-1 && matrix[i+1][j] != 101) 
               || (j > 0 && matrix[i][j-1] != 101) 
               || (i > 0 && matrix[i-1][j] != 101)){
                //do nothing
            }
            else
                break;
            
            //keep going right
            while(j < n-1 && matrix[i][j+1] != 101){
                result.Add(matrix[i][j]);
                matrix[i][j] = 101;
                j++;
            }
            
            //keep going down
            while(i < m-1 && matrix[i+1][j] != 101){
                result.Add(matrix[i][j]);
                matrix[i][j] = 101;
                i++;
            }
            
            //keep going left
            while(j > 0 && matrix[i][j-1] != 101){
                result.Add(matrix[i][j]);
                matrix[i][j] = 101;
                j--;
            }
            
            //keep going up
            while(i > 0 && matrix[i-1][j] != 101){
                result.Add(matrix[i][j]);
                matrix[i][j] = 101;
                i--;
            }
        }
        
        result.Add(matrix[i][j]);
        return result;
    }
}