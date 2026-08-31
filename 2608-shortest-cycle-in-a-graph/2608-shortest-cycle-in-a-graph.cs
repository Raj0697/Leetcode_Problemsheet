public class Solution {
    public int FindShortestCycle(int n, int[][] edges) {
        int[] vis;
        List<int>[] adj = new List<int>[n];
        for(int i=0;i<adj.Length;i++) adj[i] =  new List<int>();
        foreach(var i in edges) 
        {
            adj[i[0]].Add(i[1]);
            adj[i[1]].Add(i[0]);
        }
        int ans = int.MaxValue;
        Queue<(int,int)> q = new Queue<(int,int)>();
        for(int e=0;e<n;e++)
        {
            vis = new int[n];
            vis[e] = 1;
            q.Enqueue((e,-1));
            while(q.Count>0)
            {
                var (curr, parent) = q.Dequeue();
                foreach(var i in adj[curr])
                {
                    if(i==parent) continue;
                    if(vis[i]!=0) ans = Math.Min(vis[i]+vis[curr]-1, ans);
                    else
                    {
                        vis[i] = vis[curr]+1;   
                        q.Enqueue((i,curr));
                    }
                }
            }
            q.Clear();
        }
        return ans==int.MaxValue?-1:ans;
    }
}