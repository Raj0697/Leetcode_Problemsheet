public class Solution {
    public int MaxSum(int[] nums1, int[] nums2) {
        const int MOD = 1000000007;
        int i = 0, j = 0;
        long sum1 = 0, sum2 = 0, maxSum = 0;

        // Traverse both arrays until we reach the end of either
        while (i < nums1.Length || j < nums2.Length) {
            // Get the current values of nums1 and nums2 or set to int.MaxValue if we've exhausted one array
            int val1 = i < nums1.Length ? nums1[i] : int.MaxValue;
            int val2 = j < nums2.Length ? nums2[j] : int.MaxValue;

            // If the value from nums1 is less than the value from nums2
            if (val1 < val2) {
                sum1 += val1; // Accumulate sum from nums1
                i++; // Move to the next element in nums1
            } 
            // If the value from nums2 is less than the value from nums1
            else if (val1 > val2) {
                sum2 += val2; // Accumulate sum from nums2
                j++; // Move to the next element in nums2
            } 
            // When we encounter a common element in both arrays
            else {
                // Update the maxSum with the maximum of the two sums and add the common value
                maxSum = (maxSum + Math.Max(sum1, sum2) + val1) % MOD;
                sum1 = 0; // Reset sum1 for the next segment
                sum2 = 0; // Reset sum2 for the next segment
                i++; // Move past the common element in nums1
                j++; // Move past the common element in nums2
            }
        }

        // After finishing the traversal, add any remaining sums
        maxSum = (maxSum + Math.Max(sum1, sum2)) % MOD;

        return (int)maxSum; // Return the final maximum score modulo 10^9 + 7
    }
}