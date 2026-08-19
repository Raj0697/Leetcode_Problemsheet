public class Solution {
    public int MaximumsSplicedArray(int[] nums1, int[] nums2) {
        int n = nums1.Length;

        // Calculate the initial sums of both arrays
        int sum1 = nums1.Sum();
        int sum2 = nums2.Sum();

        // Find max possible gain from swapping a subarray from nums2 to nums1
        int maxGain1 = MaxSubarrayDifference(nums2, nums1);

        // Find max possible gain from swapping a subarray from nums1 to nums2
        int maxGain2 = MaxSubarrayDifference(nums1, nums2);

        // The final result is the maximum score possible after optimal swap
        return Math.Max(sum1 + maxGain1, sum2 + maxGain2);
    }

    // Function to calculate the maximum subarray sum difference: nums1[i] - nums2[i]
    private int MaxSubarrayDifference(int[] nums1, int[] nums2) {
        int n = nums1.Length;
        int maxGain = 0;
        int currentGain = 0;

        for (int i = 0; i < n; i++) {
            // Calculate the difference at index i
            int diff = nums1[i] - nums2[i];

            // Use Kadane's Algorithm to find the max subarray sum of differences
            currentGain = Math.Max(diff, currentGain + diff);
            maxGain = Math.Max(maxGain, currentGain);
        }

        return maxGain;
    }
}