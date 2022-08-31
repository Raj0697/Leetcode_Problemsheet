class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        int m = matrix.length;
        int n = matrix[0].length;
        
        int r = m-1;
        int c = 0;
        
        while(r>=0 && c <n){
            if(matrix[r][c] == target){
                return true;
            }
            else if(matrix[r][c] < target){
                c++;
            }
            else
                r--;
        }
        
        return false;
      /*  int r = matrix.length, c = matrix[0].length;
        
        if(r == 1){
            return binarysearch(matrix, 0, 0, c-1, target);
        }
        int row = 0, col = matrix.length - 1;
        
        while(row < matrix.length && col >= 0) {
            if(matrix[row][col] == target) {
                return true;
            }
            if(matrix[row][col] < target) {
                row++;
            }
            else{
                col--;
            }
        }
        return false;
        
        
        /*
        int start=0, end =r-1, cmid = c/2;
        
        while(start < (end-1)) {
            int mid = start + (end-start) / 2;
            if(matrix[mid][cmid] == target){
                return true;
            }
            if(matrix[mid][cmid] < target) {
                start = mid;
            }
            else{
                end= mid;
            }
        }
        
        if(matrix[start][cmid] == target){
            
        }
        return false;
        */
    }
    
    public static boolean binarysearch(int[][] matrix, int row, int start, int end, int target) {
        while(start <= end) {
            int mid = start + (end-start) / 2;
            if(matrix[row][mid] == target){
                return true;
            }
            if(matrix[row][mid] < target) {
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }
        return false;
    }
}