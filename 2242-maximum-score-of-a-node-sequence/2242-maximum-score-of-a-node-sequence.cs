public class Solution
{
    public int MaximumScore(int[] scores, int[][] edges)
    {
        // Initialize a graph of HashSets. Each node can have up to 3 neighbors stored.
        List<HashSet<KeyValuePair<int, int>>> graph = new List<HashSet<KeyValuePair<int, int>>>(new HashSet<KeyValuePair<int, int>>[scores.Length]);

        // Initialize each HashSet for the nodes
        for (int i = 0; i < scores.Length; i++)
        {
            graph[i] = new HashSet<KeyValuePair<int, int>>();
        }

        // Populate the graph with edges and ensure each node has at most 3 neighbors with highest scores
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];

            // Insert the neighbors with their respective scores
            graph[u].Add(new KeyValuePair<int, int>(scores[v], v));
            graph[v].Add(new KeyValuePair<int, int>(scores[u], u));

            // Ensure that each node has no more than 3 neighbors with the highest scores
            if (graph[u].Count > 3)
                RemoveLowScoreNeighbors(graph[u]);

            if (graph[v].Count > 3)
                RemoveLowScoreNeighbors(graph[v]);
        }

        int result = -1;

        // Iterate over each edge to check all possible valid 4-node sequences
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];

            int score = scores[u] + scores[v];

            // Check all pairs of top neighbors of u and v
            foreach (var node1 in graph[u])
            {
                foreach (var node2 in graph[v])
                {
                    // Ensure the nodes are distinct and not part of the current edge
                    if (node1.Value != u && node1.Value != v && node2.Value != u && node2.Value != v && node2.Value != node1.Value)
                    {
                        result = Math.Max(result, score + node1.Key + node2.Key);
                    }
                }
            }
        }

        return result;
    }

    // Helper function to remove the lowest scoring neighbor (maintains top 3 neighbors only)
    private void RemoveLowScoreNeighbors(HashSet<KeyValuePair<int, int>> nodeSet)
    {
        if (nodeSet.Count > 3)
        {
            // Find and remove the element with the lowest score (smallest first item)
            KeyValuePair<int, int> minItem = new KeyValuePair<int, int>(int.MaxValue, -1);
            foreach (var item in nodeSet)
            {
                if (item.Key < minItem.Key)
                {
                    minItem = item;
                }
            }

            nodeSet.Remove(minItem);
        }
    }
}