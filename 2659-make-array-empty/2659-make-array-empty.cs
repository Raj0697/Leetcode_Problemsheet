public class Solution {
    public long CountOperationsToEmptyArray(int[] nums) {
        // Get the number of elements in the array
        int n = nums.Length;
        
        // Create an array of indices from 0 to n-1
        int[] indices = Enumerable.Range(0, n).ToArray();

        // Sort the indices based on the values in the 'nums' array
        // This means indices will be arranged in the order of the sorted values in 'nums'
        Array.Sort(indices, (a, b) => nums[a].CompareTo(nums[b]));
        
        // Initialize the result to count the operations
        long result = 0;

        // Loop through the sorted indices and calculate shifts
        for (int i = 1; i < n; i++) {
            // If the current index is smaller than the previous one,
            // it indicates a need to shift elements to fill the gaps
            if (indices[i] < indices[i - 1]) {
                // Calculate shifts based on current and previous positions
                long shift1 = indices[i - 1] - (i - 1);  // Shift caused by previous element
                long shift2 = (n - i) - shift1;  // Remaining shift caused by elements after the current one
                
                // Add both shifts to the result
                result += shift1 + shift2;
            }
        }

        // The result is the total number of operations, plus 'n' for the initial removal operations
        return result + n;
    }
}