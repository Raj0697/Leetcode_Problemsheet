public class Solution {
    const int N = 100_005, M = N * 2;
    int[] head = new int[N], edge = new int[M], next = new int[M];
    int[,] dp = new int[N, 5];
    int idx = 0;

    public long MaxOutput(int n, int[][] edges, int[] price) {
        Array.Fill(head, -1);
        foreach (var edgePair in edges) {
            int u = edgePair[0], v = edgePair[1];
            AddEdge(u, v);
            AddEdge(v, u);
        }

        DFS1(0, -1, price);
        DFS2(0, -1, price);

        long result = 0;
        for (int i = 0; i < n; i++)
            result = Math.Max(result, Math.Max(dp[i, 0], dp[i, 4]));

        return result;
    }

    void AddEdge(int u, int v) {
        edge[idx] = v;
        next[idx] = head[u];
        head[u] = idx++;
    }

    void DFS1(int u, int parent, int[] price) {
        for (int i = head[u]; i != -1; i = next[i]) {
            int v = edge[i];
            if (v == parent) continue;
            DFS1(v, u, price);
            int val = dp[v, 0] + price[v];
            if (val > dp[u, 0]) {
                dp[u, 1] = dp[u, 0];
                dp[u, 3] = dp[u, 2];
                dp[u, 0] = val;
                dp[u, 2] = v;
            } else if (val > dp[u, 1]) {
                dp[u, 1] = val;
                dp[u, 3] = v;
            }
        }
    }

    void DFS2(int u, int parent, int[] price) {
        for (int i = head[u]; i != -1; i = next[i]) {
            int v = edge[i];
            if (v == parent) continue;
            int fromParent = (dp[u, 2] == v ? dp[u, 1] : dp[u, 0]);
            dp[v, 4] = Math.Max(dp[u, 4], fromParent) + price[u];
            DFS2(v, u, price);
        }
    }
}