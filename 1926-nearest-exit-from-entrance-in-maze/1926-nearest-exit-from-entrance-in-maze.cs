public class Solution {
        public int NearestExit(char[][] maze, int[] entrance) {
        var dirs = new [] {0, 1, 0, -1, 0};
        var q = new Queue<(int, int, int)>();
        q.Enqueue((entrance[0], entrance[1], 0));
        
        while(q.Any())
        {
            var (i, j, dist) = q.Dequeue();
            if(i < 0 || i == maze.Length) continue;
            if(j < 0 || j == maze[i].Length) continue;
            if(maze[i][j] != '.') continue;
            maze[i][j] = '_';
            if(dist > 0 && (i == 0 || i == maze.Length - 1)) return dist;
            if(dist > 0 && (j == 0 || j == maze[i].Length - 1)) return dist;
            
            for(var k = 0; k < dirs.Length - 1; k++)
                q.Enqueue((i + dirs[k], j + dirs[k + 1], dist + 1));
        }
        
        return -1;
    }
}