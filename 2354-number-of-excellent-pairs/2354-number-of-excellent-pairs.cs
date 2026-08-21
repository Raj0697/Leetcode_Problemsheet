public class Solution {
    public long CountExcellentPairs(int[] nums, int k) {
        // A HashSet to eliminate duplicate numbers
        HashSet<int> uniqueNums = new HashSet<int>(nums);
        
        // A dictionary to store the frequency of each bit count
        Dictionary<int, int> bitCountFrequency = new Dictionary<int, int>();
        
        // Calculate the bit counts for each unique number in nums
        foreach (var num in uniqueNums) {
            int bitCount = BitCount(num);  // Count the number of 1-bits in the number
            if (bitCountFrequency.ContainsKey(bitCount)) {
                bitCountFrequency[bitCount]++;
            } else {
                bitCountFrequency[bitCount] = 1;
            }
        }
        
        long result = 0;
        
        // Check each pair of bit counts to see if their sum equals k
        foreach (var countA in bitCountFrequency.Keys) {
            foreach (var countB in bitCountFrequency.Keys) {
                if (countA + countB >= k) {
                    result += (long)bitCountFrequency[countA] * bitCountFrequency[countB];
                }
            }
        }

        return result;
    }

    private int BitCount(int x) {
        return Convert.ToString(x, 2).Count(c => c == '1');
    }

}