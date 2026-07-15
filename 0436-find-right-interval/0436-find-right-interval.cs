public class Solution {
    public int[] FindRightInterval(int[][] intervals) {
        int n = intervals.Length;
        var starts = new List<(int start, int index)>();

        for (int i = 0; i < n; i++)
            starts.Add((intervals[i][0], i));

        starts.Sort((a, b) => a.start.CompareTo(b.start));

        int[] result = new int[n];
        for (int i = 0; i < n; i++) {
            int target = intervals[i][1];
            int left = 0, right = n - 1;
            int found = -1;

            while (left <= right) {
                int mid = (left + right) / 2;
                if (starts[mid].start >= target) {
                    found = starts[mid].index;
                    right = mid - 1;  // continue to find smaller start
                } else {
                    left = mid + 1;
                }
            }

            result[i] = found;
        }

        return result;
    }
}