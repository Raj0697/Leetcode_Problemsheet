public class Solution {
    public int MaxEqualFreq(int[] nums) {
        int[] freq = new int[100001];      // Frequency of each element
        int[] count = new int[100001];     // Number of elements with a given frequency
        int maxFreq = 0;                   // Max frequency seen so far
        int result = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            int num = nums[i];
            
            // Reduce the count of the old frequency
            if (freq[num] > 0) {
                count[freq[num]]--;
            }
            
            // Increase the frequency of the current number
            freq[num]++;
            int f = freq[num];
            count[f]++;
            
            // Update maxFreq if needed
            maxFreq = Math.Max(maxFreq, f);
            
            // Total elements processed so far (i + 1)
            int totalElements = i + 1;
            
            // Check if the current prefix can be a valid candidate
            bool valid = 
                // Case 1: All numbers appear exactly once
                maxFreq == 1 || 
                
                // Case 2: All numbers but one have the same frequency, and the last has frequency one more
                (maxFreq * count[maxFreq] + (maxFreq - 1) * count[maxFreq - 1] == totalElements &&
                 count[maxFreq] == 1) ||
                
                // Case 3: All numbers have the same frequency except one that appears exactly once
                (maxFreq * count[maxFreq] + 1 == totalElements && count[1] == 1);

            // Update the result if the current prefix is valid
            if (valid) {
                result = totalElements;
            }
        }
        
        return result;
    }
}