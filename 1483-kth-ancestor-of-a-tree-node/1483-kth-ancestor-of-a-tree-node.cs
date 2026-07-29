public class TreeAncestor {
    private int[,] ancestor;
    private int maxLog;

    public TreeAncestor(int n, int[] parent) {
        maxLog = (int)Math.Log2(n) + 1;
        ancestor = new int[n, maxLog];
        
        // Initialize the first column of ancestor matrix
        for (int i = 0; i < n; i++) {
            ancestor[i, 0] = parent[i];
        }
        
        // Compute all ancestors for powers of 2
        for (int j = 1; j < maxLog; j++) {
            for (int i = 0; i < n; i++) {
                if (ancestor[i, j - 1] != -1) {
                    ancestor[i, j] = ancestor[ancestor[i, j - 1], j - 1];
                } else {
                    ancestor[i, j] = -1;
                }
            }
        }
    }
    
    public int GetKthAncestor(int node, int k) {
        for (int i = 0; i < maxLog; i++) {
            if ((k & (1 << i)) != 0) {
                node = ancestor[node, i];
                if (node == -1) {
                    return -1;
                }
            }
        }
        return node;
    }
}