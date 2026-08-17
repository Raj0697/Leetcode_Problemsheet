public class Solution {
    int maxQuality;
    int[] values;
    List<(int neighbor, int time)>[] adjList;
    int[] visited;
    int maxTime;
    public int MaximalPathQuality(int[] values, int[][] edges, int maxTime) {
        this.values = values;
        this.maxTime = maxTime;
        int n = values.Length;
        adjList = new List<(int, int)>[n];
        for(int i = 0; i < n; i++) adjList[i] = new List<(int, int)>();
        foreach(var edge in edges) {
            int u = edge[0];
            int v = edge[1];
            int time = edge[2];
            adjList[u].Add((v, time));
            adjList[v].Add((u, time));
        }
        visited = new int[n];
        int currentQuality = values[0];
        visited[0] = 1;
        maxQuality = values[0];
        dfs(0, 0, currentQuality);
        return maxQuality;
    }
    void dfs(int node, int timeUsed, int currentQuality) {
        if(timeUsed > maxTime) return;
        if(node == 0) {
            if(currentQuality > maxQuality) maxQuality = currentQuality;
        }
        foreach(var (neighbor, time) in adjList[node]) {
            int newTimeUsed = timeUsed + time;
            if(newTimeUsed > maxTime) continue;
            bool firstVisit = visited[neighbor] == 0;
            if(firstVisit) currentQuality += values[neighbor];
            visited[neighbor]++;
            dfs(neighbor, newTimeUsed, currentQuality);
            visited[neighbor]--;
            if(firstVisit) currentQuality -= values[neighbor];
        }
    }
}