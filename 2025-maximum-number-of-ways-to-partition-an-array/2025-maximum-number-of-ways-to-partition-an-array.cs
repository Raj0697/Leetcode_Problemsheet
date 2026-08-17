public class Solution {
    public int WaysToPartition(IList<int> nums, int k) {
        int n = nums.Count;
        long ans = 0, totSum = 0;

        // Calculate total sum and populate right map with prefix sums
        Dictionary<long, int> leftMap = new Dictionary<long, int>();
        Dictionary<long, int> rightMap = new Dictionary<long, int>();
        for (int i = 0; i < n; i++) {
            totSum += nums[i];
            if (i + 1 < n) {
                if (!rightMap.ContainsKey(totSum)) rightMap[totSum] = 0;
                rightMap[totSum]++;
            }
        }

        // Case 1: No change to array
        for (long i = 0, sum = 0, count = 0; i < n; i++) {
            sum += nums[(int)i];
            if (sum * 2 == totSum && i + 1 < n) {
                count++;
                ans = Math.Max(ans, count);
            }
        }

        // Case 2: Change each element one by one and calculate partitions
        for (long i = 0, sum = 0; i < n; i++) {
            long delta = k - nums[(int)i];
            sum += nums[(int)i];
            long currentCount = 0;

            // Check for partitions when changing an element (leftMap for j < i)
            if ((totSum + delta) % 2 == 0 && leftMap.TryGetValue((totSum + delta) / 2, out int leftCount)) {
                currentCount += leftCount;
            }

            // Check for partitions when changing an element (rightMap for i <= j)
            if ((totSum - delta) % 2 == 0 && rightMap.TryGetValue((totSum - delta) / 2, out int rightCount)) {
                currentCount += rightCount;
            }

            // Move the prefix sum from rightMap to leftMap as we progress
            if (rightMap.ContainsKey(sum)) {
                rightMap[sum]--;
                if (rightMap[sum] == 0) rightMap.Remove(sum);
                if (!leftMap.ContainsKey(sum)) leftMap[sum] = 0;
                leftMap[sum]++;
            }

            ans = Math.Max(ans, currentCount);
        }

        return (int)ans;
    }
}