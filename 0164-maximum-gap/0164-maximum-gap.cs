public class Solution {
    public int MaximumGap(int[] nums) {
        if (nums.Length == 1) return 0; // If there's only one element, no gap exists
int max = -1; // Initialize max difference
Array.Sort(nums); // Sort the array
for (int i = 1; i < nums.Length; i++)
{
    max = Math.Max(max, nums[i] - nums[i - 1]); // Update max difference if current diff is larger
}
return max;
    }
}