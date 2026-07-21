public class Solution {
    public int MinimumDeletions(int[] nums) {
        int n = nums.Length;
        if (n == 1) return 1;

        // Find indices of min and max
        int minVal = int.MaxValue, maxVal = int.MinValue;
        int minIdx = -1, maxIdx = -1;

        for (int i = 0; i < n; i++) {
            if (nums[i] < minVal) {
                minVal = nums[i];
                minIdx = i;
            }
            if (nums[i] > maxVal) {
                maxVal = nums[i];
                maxIdx = i;
            }
        }

        // Minimum of 3 options
        int opt1 = Math.Max(minIdx, maxIdx) + 1;           // remove from left up to farther
        int opt2 = n - Math.Min(minIdx, maxIdx);           // remove from right up to closer
        int opt3 = Math.Min(minIdx + 1, n - minIdx) +      // left to one + right to other
                   Math.Min(maxIdx + 1, n - maxIdx);

        return Math.Min(opt1, Math.Min(opt2, opt3));
    }
}