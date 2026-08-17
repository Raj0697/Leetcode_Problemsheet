using System;
using System.Collections.Generic;

public class DSU
{
    public List<int> parent;
    public List<int> rank;

    public DSU(int n)
    {
        parent = new List<int>(new int[n]);
        rank = new List<int>(new int[n]);

        for (int i = 0; i < n; i++)
        {
            parent[i] = -1; // Initialize each node as its own parent
            rank[i] = 0;    // Initialize rank to 0
        }
    }

    public int Find(int i)
    {
        if (parent[i] == -1)
        {
            return i; // If it's its own parent, return itself
        }
        return parent[i] = Find(parent[i]); // Path compression
    }

    public void Union(int a, int b)
    {
        int s1 = Find(a);
        int s2 = Find(b);

        if (s1 != s2) // If they are not already in the same set
        {
            // Union by rank
            if (rank[s1] >= rank[s2])
            {
                parent[s2] = s1; // Make s1 the parent of s2
                rank[s1] += rank[s2]; // Update the rank of s1
            }
            else
            {
                parent[s1] = s2; // Make s2 the parent of s1
                rank[s2] += rank[s1]; // Update the rank of s2
            }
        }
    }
}

public class Solution
{
    public bool[] FriendRequests(int n, IList<IList<int>> restrictions, IList<IList<int>> requests)
    {
        DSU dsu = new DSU(n); // Create an instance of DSU
        List<bool> ans = new List<bool>(); // To store the result of each request
        
        // Process each friend request
        foreach (var request in requests)
        {
            int u = request[0];
            int v = request[1];
            bool canBeFriends = true;

            // Backup the current state of the DSU
            var backupParent = new int[n];
            var backupRank = new int[n];
            Array.Copy(dsu.parent.ToArray(), backupParent, n);
            Array.Copy(dsu.rank.ToArray(), backupRank, n);
            
            dsu.Union(u, v); // Temporarily union the friends
            
            // Check all restrictions
            foreach (var restriction in restrictions)
            {
                // If both people in the restriction are in the same connected component
                if (dsu.Find(restriction[0]) == dsu.Find(restriction[1]))
                {
                    canBeFriends = false; // They cannot be friends due to restriction
                    break;
                }
            }

            if (canBeFriends)
            {
                ans.Add(true); // If no restrictions were violated, the request is successful
            }
            else
            {
                ans.Add(false); // If restrictions were violated, reject the request
                // Restore the backup if the request is rejected
                dsu.parent = new List<int>(backupParent);
                dsu.rank = new List<int>(backupRank);
            }
        }

        return ans.ToArray(); // Convert List<bool> to bool[] and return
    }
}