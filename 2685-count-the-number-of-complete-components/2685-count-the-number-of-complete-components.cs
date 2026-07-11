using System;
using System.Collections.Generic;

public class Solution {
    void BFS(int node, List<int>[] adj, bool[] vis, List<int> cmp) {
        Queue<int> q = new Queue<int>();
        q.Enqueue(node);
        vis[node] = true;

        while (q.Count > 0) {
            int n = q.Dequeue();
            cmp.Add(n);

            foreach (int nbr in adj[n]) {
                if (!vis[nbr]) {
                    q.Enqueue(nbr);
                    vis[nbr] = true;
                }
            }
        }
    }

    public int CountCompleteComponents(int n, int[][] edges) {
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++) adj[i] = new List<int>();

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        bool[] vis = new bool[n];
        int cnt = 0;

        for (int i = 0; i < n; i++) {
            if (!vis[i]) {
                List<int> cmp = new List<int>();
                BFS(i, adj, vis, cmp);

                if (cmp.TrueForAll(node => adj[node].Count == cmp.Count - 1))
                    cnt++;
            }
        }

        return cnt;
    }
}