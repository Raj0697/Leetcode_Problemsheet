public class Solution {
//     public int MakeConnected(int n, int[][] connections) {
//         if(connections.Length < n-1)
//             return -1;
//         int[] parent = new int[n];
//         for(int i=0; i<n; i++)
//             parent[i] = i;
//         int components = n;
//         foreach(int[] c in connections) {
//             int p1 = findParent(parent, c[0]);
//             int p2 = findParent(parent, c[1]);
//             if (p1 != p2) {
//                 parent[p1] = p2; // Union 2 component
//                 components--;
//             }
//         }
//         return components - 1;
//     }
    
//     private int findParent(int[] parent, int i) {
//         while (i != parent[i]) i = parent[i];
//         return i; // Without Path Compression
//     }
    public int MakeConnected(int n, int[][] connections) {
        if (n == 1)
            return 0;

        if (connections.Length < (n - 1))
            return -1;

        bool[] v = new bool[n];
        List<int>[] adj = new List<int>[n];
        foreach (var con in connections)
        {
            if (adj[con[0]] == null)
                adj[con[0]] = new List<int>();
            if (adj[con[1]] == null)
                adj[con[1]] = new List<int>();

            adj[con[0]].Add(con[1]);
            adj[con[1]].Add(con[0]);
        }
        
        int com = 0;
        for (int i = 0; i < n; i++)
        {
            if (!v[i])
            {
                TravelGraph(i, adj, v);
                com++;
            }
        }

        return com - 1;
    }

    private void TravelGraph(int i, List<int>[] adj, bool[] v)
    {
        v[i] = true;
        if (adj[i] != null)
        {
            foreach (int x in adj[i])
            {
                if (!v[x])
                    TravelGraph(x, adj, v);
            }
        }
    }
}