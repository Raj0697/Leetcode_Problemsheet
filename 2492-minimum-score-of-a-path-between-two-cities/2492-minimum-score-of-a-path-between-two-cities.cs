public class Solution {
    public int MinScore(int n, int[][] roads) {
        var graph = new Dictionary<int, Dictionary<int, int>>();
        foreach (var road in roads)
        {
            if (!graph.ContainsKey(road[0]))
            {
                graph.Add(road[0], new Dictionary<int, int>());
            }

            if (!graph.ContainsKey(road[1]))
            {
                graph.Add(road[1], new Dictionary<int, int>());
            }
            graph[road[0]].Add(road[1], road[2]);
            graph[road[1]].Add(road[0], road[2]);
        }
        var minScore = int.MaxValue;
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(1);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var adj in graph[node].Keys)
            {
                if (!visited.Contains(adj))
                {
                    queue.Enqueue(adj);
                    visited.Add(adj);
                }
                minScore = Math.Min(minScore, graph[node][adj]);
            }
        }
        return minScore;
    }
}