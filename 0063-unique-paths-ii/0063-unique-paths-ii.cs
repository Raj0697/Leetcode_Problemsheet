public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int w = obstacleGrid.Length;
        int h = obstacleGrid[0].Length;

        if(obstacleGrid[w - 1][h - 1] == 1) return 0;
        obstacleGrid[w - 1][h - 1] = 1;

        for(int x = w - 2; x >= 0; x--) {
            
            obstacleGrid[x][h - 1] =
                obstacleGrid[x][h - 1] == 1 ? 0 : obstacleGrid[x + 1][h - 1];
        }

        for(int y = h - 2; y >= 0; y--) {
            
            obstacleGrid[w - 1][y] =
                obstacleGrid[w - 1][y] == 1 ? 0 : obstacleGrid[w - 1][y + 1];
        }

        for(int x = w - 2; x >= 0; x--) {
            for(int y = h - 2; y >= 0; y--) {

                obstacleGrid[x][y] =
                    obstacleGrid[x][y] == 1 ? 0 : obstacleGrid[x + 1][y] + obstacleGrid[x][y + 1];
            }
        }

        return obstacleGrid[0][0];
    }
}