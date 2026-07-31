public class Solution {
    public int MaxValueAfterReverse(int[] nums) {
        int n = nums.Length;
        int initialValue = 0;

        for(int i = 0; i < n - 1; i++) initialValue += Math.Abs(nums[i] - nums[i + 1]);
        
        int maxGain = 0;
        for (int i = 1; i < n - 1; i++) {
            maxGain = Math.Max(maxGain, Math.Abs(nums[0] - nums[i + 1]) - Math.Abs(nums[i] - nums[i + 1]));
            maxGain = Math.Max(maxGain, Math.Abs(nums[n - 1] - nums[i - 1]) - Math.Abs(nums[i] - nums[i - 1]));
        }
        int min2 = int.MaxValue, max2 = int.MinValue;

        for (int i = 1; i < n; i++) {
            int a = nums[i - 1], b = nums[i];
            min2 = Math.Min(min2, Math.Max(a, b));
            max2 = Math.Max(max2, Math.Min(a, b));
        }

        maxGain = Math.Max(maxGain, 2 * (max2 - min2));
        return initialValue + maxGain;
    }
}