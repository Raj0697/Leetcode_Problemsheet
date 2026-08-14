public class Solution {
    public int MinCost(int maxTime, int[][] edges, int[] passingFees) {
        int n = passingFees.Length;

        // Build adjacency list: graph[node] -> (neighbor, travelTime)
        var graph = new List<(int,int)>[n];
        for (int i = 0; i < n; i++) graph[i] = new List<(int,int)>();
        foreach (var e in edges) {
            graph[e[0]].Add((e[1], e[2]));
            graph[e[1]].Add((e[0], e[2]));
        }

        // dp[node][time] = min cost to reach node at exact time
        int[,] dp = new int[n, maxTime+1];
        for (int i = 0; i < n; i++)
            for (int t = 0; t <= maxTime; t++)
                dp[i,t] = int.MaxValue;

        var pq = new PriorityQueue<(int cost,int node,int time), int>();
        dp[0,0] = passingFees[0];
        pq.Enqueue((passingFees[0], 0, 0), passingFees[0]);

        while (pq.Count > 0) {
            var (cost, node, time) = pq.Dequeue();
            if (node == n-1) return cost;

            foreach (var (nei, tEdge) in graph[node]) {
                int newTime = time + tEdge;
                if (newTime <= maxTime) {
                    int newCost = cost + passingFees[nei];
                    if (newCost < dp[nei,newTime]) {
                        dp[nei,newTime] = newCost;
                        pq.Enqueue((newCost, nei, newTime), newCost);
                    }
                }
            }
        }
        return -1;
    }
}