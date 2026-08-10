public class Solution {
    public int KthSmallest(int[][] mat, int k) {
        int m = mat.Length;
        int n = mat[0].Length;
        var pq = new PriorityQueue<(int[] combo, int sum), int>();
        var visited = new HashSet<string>();

        int[] start = new int[m];
        int startSum = 0;
        for (int i = 0; i < m; i++) startSum += mat[i][0];

        pq.Enqueue((start, startSum), startSum);
        visited.Add(string.Join(",", start));

        while (k-- > 0) {
            var (combo, sum) = pq.Dequeue();
            if (k == 0) return sum;

            for (int i = 0; i < m; i++) {
                if (combo[i] + 1 < mat[i].Length) {
                    int[] next = (int[])combo.Clone();
                    next[i]++;
                    int nextSum = sum - mat[i][combo[i]] + mat[i][next[i]];
                    string key = string.Join(",", next);
                    if (!visited.Contains(key)) {
                        visited.Add(key);
                        pq.Enqueue((next, nextSum), nextSum);
                    }
                }
            }
        }

        return -1;
    }
}