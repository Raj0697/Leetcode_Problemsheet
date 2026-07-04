public class Solution {
    public int MinScore(int n, int[][] roads) {
        Dictionary<int, List<(int, int)>> adj = new();
        foreach (int[] detail in roads)
        {
            _ = adj.TryAdd(detail[0], new());
            adj[detail[0]].Add((detail[1], detail[2]));
            _ = adj.TryAdd(detail[1], new());
            adj[detail[1]].Add((detail[0], detail[2]));
        }

        int[] distances = new int[n + 1];
        Array.Fill(distances, int.MaxValue);

        HashSet<int> visited = new();
        PriorityQueue<int, int> queue = new();
        queue.Enqueue(1, 0);
        int min = int.MaxValue;
        while (queue.Count > 0)
        {
            _ = queue.TryDequeue(out int origin, out int distance);
            if (visited.Contains(origin))
            {
                continue;
            }

            visited.Add(origin);
            distances[origin] = distance;
            foreach ((int neighbor, int neighborDistance) in adj[origin])
            {
                min = Math.Min(min, neighborDistance);
                int newDistance = distance + neighborDistance;
                if (distances[neighbor] > newDistance)
                {
                    distances[neighbor] = newDistance;
                    queue.Enqueue(neighbor, newDistance);
                }
            }
        }

        return min;
    }
}