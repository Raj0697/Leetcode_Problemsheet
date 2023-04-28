public class Solution {
    public int NumSimilarGroups(string[] strs) {
        int n = strs.Length;
        var uf = new UnionFind(n);
        
        for (int i=0; i<n-1; i++) {
            for (int j=i+1; j<n; j++) {
                if (IsSimilar(strs[i], strs[j])) {
                    uf.Union(i, j);
                    if (uf.groups == 1) return 1;
                }
            }
        }
        
        return uf.groups;
    }
    
    public bool IsSimilar(string word1, string word2) {
        var diff = 0;
        for (int i=0; i<word1.Length; i++) {
            if (word1[i] != word2[i]) {
                diff++;
            }
            if (diff == 3) return false;
        }
        
        return true;
    }
}
public class UnionFind {
    public int[] parent, rank;
    public int groups;
    
    public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i=0; i<n; i++) {
            parent[i] = i;
        }
        groups = n; // initially set as n
    }
    
    public int Find(int x) {
        while (parent[x] != x) {
            return Find(parent[x]);
        }
        return x;
    }
    
    public void Union(int x, int y) {
        int px = Find(x);
        int py = Find(y);
        if (px == py) return;
        
        if (rank[px] > rank[py]) {
            parent[py] = px;
            rank[px]++;
        } else {
            parent[px] = py;
            rank[py]++;
        }
        groups--;
    }
}