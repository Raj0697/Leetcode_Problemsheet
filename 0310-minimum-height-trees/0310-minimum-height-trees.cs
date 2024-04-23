public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1) return new List<int> { 0 };

        List<HashSet<int>> adj = new List<HashSet<int>>(n);
        for (int i = 0; i < n; i++)
            adj.Add(new HashSet<int>());

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        var indegree = new int[n];
        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < n; i++) {
            indegree[i] = adj[i].Count;
            if (indegree[i] == 1) queue.Enqueue(i);
        }

        while (n > 2) {
            int size = queue.Count;
            n -= size;
            for (int i = 0; i < size; i++) {
                int node = queue.Dequeue();
                foreach (var neighbor in adj[node]) {
                    indegree[neighbor]--;
                    if (indegree[neighbor] == 1) queue.Enqueue(neighbor);
                }
            }
        }

        List<int> result = new List<int>();
        while (queue.Count > 0) {
            result.Add(queue.Dequeue());
        }

        return result;
    }
}