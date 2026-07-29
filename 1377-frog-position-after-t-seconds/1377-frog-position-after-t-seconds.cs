public class Solution
{
    public double FrogPosition(int n, int[][] edges, int t, int target)
    {
        var graph = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }
        
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int> { 1 };
        return DFS(1, t, target, visited, graph);
    }

    private double DFS(int current, int time, int target, HashSet<int> visited, Dictionary<int, List<int>> graph)
    {
        // If the frog is at the target and no time left, return 1.0
        if (time == 0)
            return current == target ? 1.0 : 0.0;

        var neighbors = graph[current];
        int unvisitedCount = 0;

        foreach (var neighbor in neighbors)
        {
            if (!visited.Contains(neighbor))
                unvisitedCount++;
        }

        // If there are no unvisited neighbors
        if (unvisitedCount == 0)
            return current == target ? 1.0 : 0.0;

        double probability = 0.0;

        foreach (var neighbor in neighbors)
        {
            if (!visited.Contains(neighbor))
            {
                visited.Add(neighbor);
                probability += DFS(neighbor, time - 1, target, visited, graph) / unvisitedCount;
                visited.Remove(neighbor);
            }
        }

        return probability;
    }
}