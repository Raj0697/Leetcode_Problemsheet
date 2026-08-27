class Solution {
    public long MakeSimilar(int[] V, int[] T) {
        var v = new List<long>[] { new List<long>(), new List<long>() };
        var t = new List<long>[] { new List<long>(), new List<long>() };

        foreach (int x in V) v[x % 2].Add(x);
        foreach (int x in T) t[x % 2].Add(x);

        for (int i = 0; i < 2; i++) {
            v[i].Sort();
            t[i].Sort();
        }

        long ans = 0;
        for (int i = 0; i < v[0].Count; i++) ans += Math.Abs(v[0][i] - t[0][i]) / 2;
        for (int i = 0; i < v[1].Count; i++) ans += Math.Abs(v[1][i] - t[1][i]) / 2;

        return ans / 2;
    }
}