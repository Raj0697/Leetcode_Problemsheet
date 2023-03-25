public class Solution {
    public long CountPairs(int n, int[][] edges) {
        
        DisjointSet connections = new(n);
        
        for (int i = 0; i < edges.Length; i++)
            connections.Union(edges[i][0], edges[i][1]);    
        
        return connections.TotalDisconnectedPairs;        
    }
    
    class DisjointSet
    {
        private readonly int[] parents;
        private readonly int[] ranks;
        
        public long TotalDisconnectedPairs { get; private set; }
        
        public DisjointSet(int size)
        {
            parents = new int[size];
            ranks = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                parents[i] = i;
                ranks[i] = 1;
            }
            
            // the initial number of disconnected pairs is the number of edges in a fully connected graph - n * (n - 1) / 2
            TotalDisconnectedPairs = (long)size * (size - 1) / 2;
        }
        
        public int Find(int node) => node == parents[node] ? node : (parents[node] = Find(parents[node]));
        
        public bool Union(int left, int right)
        {
            int leftRoot = Find(left);
            int rightRoot = Find(right);

            if (leftRoot == rightRoot) return false;
            
            // now that the 'left' and 'right' subsets are about to merge,
            // we can substract the total number of newly connected pairs in the resulting
            // set from the remaining disconnected ones
            TotalDisconnectedPairs -= ranks[leftRoot] * ranks[rightRoot];

            int diff = ranks[leftRoot] - ranks[rightRoot];            
            
            if (diff >= 0)
            {                                
                parents[rightRoot] = leftRoot;
                ranks[leftRoot] += ranks[rightRoot];
            }
            else
            {
                parents[leftRoot] = rightRoot;
                ranks[rightRoot] += ranks[leftRoot];
            }

            return true;
        }
    }
}