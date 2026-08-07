public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        int n = nums.Length;
        if (n == 0) return 0;
        
        int[] lengths = new int[n]; // To store the length of the longest increasing subsequence ending at each index
        int[] counts = new int[n];  // To store the count of such subsequences
        
        // Initialize lengths and counts arrays with default values
        for (int i = 0; i < n; i++) {
            lengths[i] = 1; // Each element is an increasing subsequence of length 1
            counts[i] = 1;  // Each element itself is a subsequence
        }
        
        int maxLength = 1;
        
        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (nums[i] > nums[j]) {
                    if (lengths[j] + 1 > lengths[i]) {
                        lengths[i] = lengths[j] + 1;
                        counts[i] = counts[j];
                    } else if (lengths[j] + 1 == lengths[i]) {
                        counts[i] += counts[j];
                    }
                }
            }
            maxLength = Math.Max(maxLength, lengths[i]);
        }
        
        int result = 0;
        for (int i = 0; i < n; i++) {
            if (lengths[i] == maxLength) {
                result += counts[i];
            }
        }
        
        return result;
    }
}