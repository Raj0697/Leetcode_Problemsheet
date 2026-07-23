using System;
using System.Collections.Generic;

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        int[] inDegree = new int[numCourses];
        var adj = new Dictionary<int, List<int>>();

    foreach (var pre in prerequisites) {
        if (!adj.ContainsKey(pre[1])) adj[pre[1]] = new List<int>();
            adj[pre[1]].Add(pre[0]);
        }

        foreach (var key in adj.Keys)
            foreach (var node in adj[key])
                inDegree[node]++;

        var q = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
            if (inDegree[i] == 0) q.Enqueue(i);

        var ans = new List<int>();
        while (q.Count > 0) {
            int node = q.Dequeue();
            ans.Add(node);
            if (adj.ContainsKey(node)) {
                foreach (var ngbr in adj[node]) {
                    inDegree[ngbr]--;
                    if (inDegree[ngbr] == 0) q.Enqueue(ngbr);
                }
            }
        }

        return ans.Count == numCourses ? ans.ToArray() :new int[0];
    }
}