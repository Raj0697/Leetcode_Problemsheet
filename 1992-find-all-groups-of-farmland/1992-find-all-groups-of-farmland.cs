public class Solution {
    public int[][] FindFarmland(int[][] land) {
        var answer = new List<int[]>();
        
        for(int row = 0; row < land.Length; row++){
            for(int col = 0; col < land[row].Length; col++){
                if( (land[row][col] == 1) &&
                    ( (row == 0) || (land[row-1][col] != 1) ) &&
                    ( (col == 0) || (land[row][col-1] != 1)) ){
                    // we found a top left that starts a new farm
                    // search down and to the right to figure out how big it is
                    int bottom = row;
                    int right = col;
                    while( (bottom < land.Length) && (land[bottom][col]) == 1 ) bottom++;
                    while( (right < land[row].Length) && (land[row][right]) == 1 ) right++;
                    // bottom and right are both one larger than desired
                    answer.Add(new int[] {row, col, --bottom, --right});
                }
            }
        }
        
        return answer.ToArray();
    }
}