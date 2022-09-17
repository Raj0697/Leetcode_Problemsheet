class Solution {
    public boolean checkValid(int[][] matrix) {
        int n = matrix.length;
    
        for(int r = 0; r < n; r++){
        
            boolean[] rvis = new boolean[n+1];//boolean row
            boolean[] cvis = new boolean[n+1];//boolean column

            for(int c = 0; c < n; c++){
                int rval = matrix[r][c]; //checking row-wise
                int cval = matrix[c][r]; // checking column-wise

                if(rvis[rval] == true || cvis[cval] == true){
                    return false; //value occurs nore than once hence it's an invalid matrix
                }
                rvis[rval] = true;
                cvis[cval] = true;
            }
        
        }   
        return true;
    }
}