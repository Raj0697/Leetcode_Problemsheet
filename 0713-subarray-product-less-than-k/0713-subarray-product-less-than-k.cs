public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        if (k <= 1) return 0; // Since all numbers are positive, if k <= 1, no subarray will satisfy the condition
        int count = 0;
        int product = 1;
        int left = 0;
        
        for (int right = 0; right < nums.Length; right++) {
            product *= nums[right];
            while (product >= k && left <= right) {
                product /= nums[left];
                left++;
            }
            count += right - left + 1; // Adding the number of subarrays ending at 'right'
        }
        
        return count;
    }
}