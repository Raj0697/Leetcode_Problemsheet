public class Solution {
    private readonly int[][] directions = new int[][] {
        new int[]{1, 0},
        new int[]{-1, 0},
        new int[]{0, 1},
        new int[]{0, -1}
    };
    public int LatestDayToCross(int row, int col, int[][] cells) {
        int left = 1, right = row * col;
        int answer = 0;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (CanCross(row, col, cells, mid)) {
                answer = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return answer;
    }
    private bool CanCross(int row, int col, int[][] cells, int day) {
        int[,] grid = new int[row, col];

        // Flood cells up to the given day
        for (int i = 0; i < day; i++) {
            int r = cells[i][0] - 1;
            int c = cells[i][1] - 1;
            grid[r, c] = 1;
        }

        bool[,] visited = new bool[row, col];
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Start BFS from top row
        for (int c = 0; c < col; c++) {
            if (grid[0, c] == 0) {
                queue.Enqueue((0, c));
                visited[0, c] = true;
            }
        }

        // BFS traversal
        while (queue.Count > 0) {
            var (r, c) = queue.Dequeue();

            if (r == row - 1)
                return true;

            foreach (var dir in directions) {
                int nr = r + dir[0];
                int nc = c + dir[1];

                if (nr >= 0 && nr < row &&
                    nc >= 0 && nc < col &&
                    !visited[nr, nc] &&
                    grid[nr, nc] == 0) {

                    visited[nr, nc] = true;
                    queue.Enqueue((nr, nc));
                }
            }
        }

        return false;
    }
}