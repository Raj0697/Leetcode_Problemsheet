public class Solution {
    private static readonly int[][] directions = { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };

    public int ContainVirus(int[][] isInfected) {
        int m = isInfected.Length, n = isInfected[0].Length, totalWalls = 0;
        
        while (true) {
            List<HashSet<int>> regions = new();
            List<HashSet<int>> threats = new();
            List<int> wallsNeeded = new();
            bool[] visited = new bool[m * n];

            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (isInfected[i][j] == 1 && !visited[i * n + j]) {
                        HashSet<int> region = new(), threat = new();
                        int walls = 0;
                        DFS(isInfected, visited, i, j, n, region, threat, ref walls);
                        regions.Add(region);
                        threats.Add(threat);
                        wallsNeeded.Add(walls);
                    }
                }
            }

            if (regions.Count == 0) break;

            int maxThreatIndex = 0;
            for (int i = 1; i < threats.Count; i++) {
                if (threats[i].Count > threats[maxThreatIndex].Count)
                    maxThreatIndex = i;
            }

            totalWalls += wallsNeeded[maxThreatIndex];

            foreach (int cell in regions[maxThreatIndex])
                isInfected[cell / n][cell % n] = -1;

            for (int i = 0; i < regions.Count; i++) {
                if (i != maxThreatIndex)
                    foreach (int cell in threats[i])
                        isInfected[cell / n][cell % n] = 1;
            }
        }

        return totalWalls;
    }

    private void DFS(int[][] isInfected, bool[] visited, int i, int j, int n, HashSet<int> region, HashSet<int> threat, ref int walls) {
        int m = isInfected.Length;
        Stack<int> stack = new();
        stack.Push(i * n + j);

        while (stack.Count > 0) {
            int cell = stack.Pop();
            i = cell / n;
            j = cell % n;
            if (visited[cell]) continue;
            visited[cell] = true;
            region.Add(cell);

            foreach (var dir in directions) {
                int ni = i + dir[0], nj = j + dir[1], nextCell = ni * n + nj;
                if (ni >= 0 && ni < m && nj >= 0 && nj < n) {
                    if (isInfected[ni][nj] == 0) {
                        threat.Add(nextCell);
                        walls++;
                    } else if (isInfected[ni][nj] == 1 && !visited[nextCell]) {
                        stack.Push(nextCell);
                    }
                }
            }
        }
    }
}