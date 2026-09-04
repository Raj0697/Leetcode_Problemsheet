public class Solution {
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        List<List<int>> graph = new List<List<int>>();
        for (int i = 0; i < n; i++)
            graph.Add(new List<int>());

        // Build adjacency list
        foreach (var e in edges)
        {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }

        bool[] visited = new bool[n];
        int components = 0;

        int rootRemainder = DFS(0, graph, values, k, visited, ref components);

        // IMPORTANT: root also forms a component if divisible
        if (rootRemainder % k == 0)
            components++;

        return components;
    }
    private int DFS(int node, List<List<int>> graph, int[] values, int k,
                    bool[] visited, ref int components)
    {
        visited[node] = true;
        long sum = values[node];

        foreach (int nbr in graph[node])
        {
            if (!visited[nbr])
            {
                int childRemainder = DFS(nbr, graph, values, k, visited, ref components);

                if (childRemainder % k == 0)
                {
                    // child subtree forms its own component
                    components++;
                }
                else
                {
                    sum += childRemainder;
                }
            }
        }

        return (int)(sum % k);
    }
}