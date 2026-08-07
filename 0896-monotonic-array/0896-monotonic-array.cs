public class Solution {
    public bool IsMonotonic(int[] nums) {
        if (nums.Length == 1) {
            return true;
        }
        bool increasing = true;
        bool decreasing = true;
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i-1]) {
                decreasing = false;
            } else if (nums[i] < nums[i-1]) {
                increasing = false;
            }
            if (!increasing && !decreasing) {
                return false;
            }
        }
        return true;
    }
}