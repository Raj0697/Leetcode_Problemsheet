public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        var ans = new int[queries.Length];
        var queryIndices = new int[queries.Length];
        var pq = new PriorityQueue<int, int>(); // <right, size>
        var ii = 0; // intervals index

        for (var i = 0; i < queries.Length; ++i) {
            queryIndices[i] = i;
        }

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        Array.Sort(queryIndices, (a, b) => queries[a].CompareTo(queries[b]));

        for (var i = 0; i < queries.Length; ++i) {
            for (; ii < intervals.Length && intervals[ii][0] <= queries[queryIndices[i]]; ++ii) {
                if (intervals[ii][1] >= queries[queryIndices[i]]) {
                    pq.Enqueue(intervals[ii][1], intervals[ii][1] - intervals[ii][0] + 1);
                }
            }

            var size = 0;

            while (pq.TryPeek(out var right, out size) && right < queries[queryIndices[i]]) {
                pq.Dequeue();
            }

            ans[queryIndices[i]] = size > 0 ? size : -1;
        }

        return ans;
    }
}