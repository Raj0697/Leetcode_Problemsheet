public class Solution {
    // Path compression only
    public int Find(int[] parent, int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent, parent[x]);
        }
        return parent[x];
    }

    // Union without rank array
    public void Union(int[] parent, int x, int y) {
        int rootX = Find(parent, x);
        int rootY = Find(parent, y);
        if (rootX != rootY) {
            parent[rootY] = rootX;
        }
    }

    public IList<bool> AreConnected(int n, int threshold, int[][] queries) {
        int[] parent = new int[n + 1];

        // Initialize the Union-Find parent array
        for (int i = 1; i <= n; i++) {
            parent[i] = i;
        }

        // For each number greater than threshold, union its multiples
        for (int i = threshold + 1; i <= n; i++) {
            for (int multiple = i * 2; multiple <= n; multiple += i) {
                Union(parent, i, multiple);
            }
        }

        // Answer each query
        IList<bool> result = new List<bool>();
        foreach (var query in queries) {
            int a = query[0], b = query[1];
            result.Add(Find(parent, a) == Find(parent, b));
        }

        return result;
    }
}