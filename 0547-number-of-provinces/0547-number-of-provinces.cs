public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        int count = 0;
        HashSet<int> h = new HashSet<int>();
        for (int i = 0; i < isConnected.Length; i++)
        {
            if (!h.Contains(i))
            {
                h.Add(i);
                DFS(isConnected, i, h);
                count++;
            }
        }
        
        return count;
    }
    
    private void DFS(int[][] graph, int i, HashSet<int> h)
    {
        for (int j = 0; j < graph[i].Length; j++)
        {
            if (i != j && graph[i][j] == 1 && !h.Contains(j))
            {
                h.Add(j);
                DFS(graph, j, h);
            }
        }
    }
}