public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length;
        int count = 0;
        int prefixXor = 0;
        
        // Dictionary to store frequency of prefix XOR values
        Dictionary<int, int> prefixXorCount = new Dictionary<int, int>();
        // Dictionary to store cumulative sum of indices for prefix XOR values
        Dictionary<int, int> prefixXorSum = new Dictionary<int, int>();
        
        // Initialize with the base case
        prefixXorCount[0] = 1;
        prefixXorSum[0] = 0;
        
        for (int i = 0; i < n; i++) {
            prefixXor ^= arr[i];
            
            if (prefixXorCount.ContainsKey(prefixXor)) {
                // Number of valid triplets ending at i
                count += prefixXorCount[prefixXor] * i - prefixXorSum[prefixXor];
                
                // Update the dictionaries
                prefixXorCount[prefixXor]++;
                prefixXorSum[prefixXor] += i + 1;
            } else {
                prefixXorCount[prefixXor] = 1;
                prefixXorSum[prefixXor] = i + 1;
            }
        }
        
        return count;
    }
}