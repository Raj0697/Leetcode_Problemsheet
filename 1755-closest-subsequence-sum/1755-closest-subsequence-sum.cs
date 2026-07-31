public class Solution {
    public int MinAbsDifference(int[] nums, int goal) {
        int n = nums.Length;
        int mid = n / 2;

        // Generate subset sums for left half
        List<int> leftSums = new List<int>();
        GenerateSums(nums, 0, mid, 0, leftSums);

        // Generate subset sums for right half
        List<int> rightSums = new List<int>();
        GenerateSums(nums, mid, n, 0, rightSums);

        // Sort right sums for binary search
        rightSums.Sort();

        int res = int.MaxValue;

        foreach (int sum in leftSums) {
            int target = goal - sum;
            // Binary search in rightSums
            int idx = rightSums.BinarySearch(target);
            if (idx < 0) idx = ~idx;

            if (idx < rightSums.Count) {
                res = Math.Min(res, Math.Abs(sum + rightSums[idx] - goal));
            }
            if (idx > 0) {
                res = Math.Min(res, Math.Abs(sum + rightSums[idx - 1] - goal));
            }
        }

        return res;
    }

    private void GenerateSums(int[] nums, int start, int end, int sum, List<int> list) {
        if (start == end) {
            list.Add(sum);
            return;
        }
        GenerateSums(nums, start + 1, end, sum, list);
        GenerateSums(nums, start + 1, end, sum + nums[start], list);
    }
}