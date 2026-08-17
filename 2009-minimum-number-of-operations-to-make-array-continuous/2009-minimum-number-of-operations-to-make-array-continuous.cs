public class Solution {
    public int MinOperations(int[] nums) {
        HashSet<int> uniqueNums = new HashSet<int>(nums); // Store unique elements
        int n = uniqueNums.Count;
        int[] sortedNums = new int[n];
        uniqueNums.CopyTo(sortedNums); // Copy unique elements to an array

        Array.Sort(sortedNums); // Sort the unique array

        int minOperations = nums.Length; // Initialize min operations to total length
        int r = 0;

        // Sliding window to determine the minimum operations
        for (int l = 0; l < sortedNums.Length; l++) {
            while (r < sortedNums.Length && sortedNums[r] <= sortedNums[l] + nums.Length - 1) {
                r++;
            }
            minOperations = Math.Min(minOperations, nums.Length - (r - l)); // Update min operations
        }

        return minOperations; // Return the result
    }
}