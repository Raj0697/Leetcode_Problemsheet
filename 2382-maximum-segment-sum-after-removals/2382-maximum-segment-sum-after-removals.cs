public class Solution {
    public long[] MaximumSegmentSum(int[] nums, int[] removeQueries) {
        int n = nums.Length;
        long[] result = new long[n];
        long[] segmentSum = new long[n];
        int[] parent = new int[n];
        bool[] active = new bool[n];

        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }

        long maxSum = 0;

        int Find(int x) {
            if (parent[x] != x) {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        void Union(int x, int y) {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY) {
                parent[rootY] = rootX;
                segmentSum[rootX] += segmentSum[rootY];
                segmentSum[rootY] = 0;
            }
        }

        for (int i = n - 1; i > 0; i--) {
            int query = removeQueries[i];
            active[query] = true;
            segmentSum[query] = nums[query];

            if (query > 0 && active[query - 1]) {
                Union(query, query - 1);
            }
            if (query < n - 1 && active[query + 1]) {
                Union(query, query + 1);
            }

            maxSum = Math.Max(maxSum, segmentSum[Find(query)]);
            result[i - 1] = maxSum;
        }

        result[n - 1] = 0; // No active elements in the final result
        return result;
    }
}