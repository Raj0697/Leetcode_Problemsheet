public class Solution {
    public int[] CountPairs(int n, int[][] edges, int[] queries) {
        int[] deg = new int[n + 1];
        Dictionary<(int,int), int> pairCount = new Dictionary<(int,int), int>();

        // Step 1: degree count and pair multiplicity
        foreach (var e in edges) {
            int u = e[0], v = e[1];
            deg[u]++;
            deg[v]++;
            if (u > v) (u, v) = (v, u);
            if (!pairCount.ContainsKey((u, v))) pairCount[(u, v)] = 0;
            pairCount[(u, v)]++;
        }

        // Step 2: sort degrees
        int[] sortedDeg = new int[n];
        for (int i = 1; i <= n; i++) sortedDeg[i - 1] = deg[i];
        Array.Sort(sortedDeg);

        int[] ans = new int[queries.Length];

        // Step 3: process each query
        for (int qi = 0; qi < queries.Length; qi++) {
            int q = queries[qi];
            int count = 0;
            int l = 0, r = n - 1;

            // two-pointer counting
            while (l < r) {
                if (sortedDeg[l] + sortedDeg[r] > q) {
                    count += (r - l);
                    r--;
                } else {
                    l++;
                }
            }

            // Step 4: adjust for overcounting
            foreach (var kv in pairCount) {
                int u = kv.Key.Item1, v = kv.Key.Item2, c = kv.Value;
                if (deg[u] + deg[v] > q && deg[u] + deg[v] - c <= q) {
                    count--;
                }
            }

            ans[qi] = count;
        }

        return ans;
    }
}