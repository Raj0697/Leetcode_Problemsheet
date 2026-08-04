using System;
using System.Collections.Generic;

public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        int[,] times = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                times[i, j] = int.MaxValue;
            }
        }
        times[0, 0] = grid[0][0];

        var minHeap = new PriorityQueue<(int, int), int>();
        minHeap.Enqueue((0, 0), grid[0][0]);

        int[] directions = { -1, 0, 1, 0, 0, -1, 0, 1 };

        while (minHeap.Count > 0) {
            var (x, y) = minHeap.Dequeue();
            int currentTime = times[x, y];

            if (x == n - 1 && y == n - 1) return currentTime;

            for (int i = 0; i < 4; i++) {
                int nx = x + directions[2 * i];
                int ny = y + directions[2 * i + 1];

                if (nx >= 0 && nx < n && ny >= 0 && ny < n) {
                    int newTime = Math.Max(currentTime, grid[nx][ny]);
                    if (newTime < times[nx, ny]) {
                        times[nx, ny] = newTime;
                        minHeap.Enqueue((nx, ny), newTime);
                    }
                }
            }
        }

        return -1; // In case there's no valid path
    }
}