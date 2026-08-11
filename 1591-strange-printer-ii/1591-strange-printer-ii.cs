public class Solution {
    public bool IsPrintable(int[][] targetGrid) {
        int m = targetGrid.Length;
        int n = targetGrid[0].Length;
        const int C = 61; // colors 1..60

        // Step 1: For each color, find bounding box
        int[] minRow = new int[C];
        int[] maxRow = new int[C];
        int[] minCol = new int[C];
        int[] maxCol = new int[C];
        Array.Fill(minRow, int.MaxValue);
        Array.Fill(maxRow, int.MinValue);
        Array.Fill(minCol, int.MaxValue);
        Array.Fill(maxCol, int.MinValue);

        bool[] used = new bool[C];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int color = targetGrid[i][j];
                used[color] = true;
                minRow[color] = Math.Min(minRow[color], i);
                maxRow[color] = Math.Max(maxRow[color], i);
                minCol[color] = Math.Min(minCol[color], j);
                maxCol[color] = Math.Max(maxCol[color], j);
            }
        }

        // Step 2: Build dependency graph
        // adj[c] = list of colors that must be printed AFTER c (c before them)
        List<int>[] adj = new List<int>[C];
        for (int i = 0; i < C; i++) adj[i] = new List<int>();

        for (int c = 1; c < C; c++) {
            if (!used[c]) continue;

            int r1 = minRow[c], r2 = maxRow[c];
            int c1 = minCol[c], c2 = maxCol[c];

            // Check every cell in bounding box of color c
            for (int i = r1; i <= r2; i++) {
                for (int j = c1; j <= c2; j++) {
                    int other = targetGrid[i][j];
                    if (other == c) continue;

                    // other must be printed AFTER c (c before other)
                    adj[c].Add(other);
                }
            }
        }

        // Step 3: Topological sort — check for cycles
        int[] indegree = new int[C];
        foreach (var list in adj) {
            foreach (int to in list) indegree[to]++; 
        }

        Queue<int> q = new Queue<int>();
        int processed = 0;
        for (int c = 1; c < C; c++) {
            if (used[c] && indegree[c] == 0) q.Enqueue(c);
            
        }

        while (q.Count > 0) {
            int cur = q.Dequeue();
            processed++;

            foreach (int next in adj[cur]) {
                indegree[next]--;
                if (indegree[next] == 0) q.Enqueue(next);

            }
        }

        // If all used colors were processed → no cycle → possible
        int usedCount = 0;
        for (int c = 1; c < C; c++) if (used[c]) usedCount++;

        return processed == usedCount;
    }
}