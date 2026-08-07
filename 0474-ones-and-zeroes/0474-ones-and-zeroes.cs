public class Solution {
     public int FindMaxForm(string[] strs, int m, int n)
 {
     // Dictionary to cache the count of ones and zeros for each string
     // Key: string index, Value: tuple of (ones count, zeros count)
     Dictionary<int, (int ones, int zeros)> counts = [];

     // Pre-compute the counts of ones and zeros for each string
     for (var i = 0; i < strs.Length; i++)
     {
         var ones = 0;
         var zeros = 0;
         foreach (var ch in strs[i])
         {
             ones += ch == '1' ? 1 : 0;
             zeros += ch == '0' ? 1 : 0;
         }
         counts[i] = (ones, zeros);
     }

     // Memoization dictionary to store previously computed results
     // Key: tuple of (current index, total ones used, total zeros used)
     // Value: maximum subset size possible from this state
     Dictionary<(int index, int totalOnes, int totalZeros), int> memo = [];

     // Recursive helper function using dynamic programming
     int DP(int index, int ones, int zeros)
     {
         // Base case: if we've processed all strings, return 0
         if (index >= strs.Length)
         {
             return 0;
         }

         // If we've already computed this state, return cached result
         if (memo.TryGetValue((index, ones, zeros), out var value))
         {
             return value;
         }

         // Get the counts for current string
         var (currOnes, currZeros) = counts[index];
         int result;

         // Check if we can include the current string without exceeding limits
         if (ones + currOnes <= n && zeros + currZeros <= m)
         {
             // We have two choices:
             // 1. Include the current string (add 1 to result and update counts)
             // 2. Skip the current string (keep current counts)
             result = Math.Max(
                 1 + DP(index + 1, ones + currOnes, zeros + currZeros), // include current string
                 DP(index + 1, ones, zeros) // skip current string
             );
         }
         else
         {
             // Can't include current string as it would exceed limits
             // Only option is to skip it
             result = DP(index + 1, ones, zeros);
         }

         // Cache the result before returning
         memo[(index, ones, zeros)] = result;
         return result;
     }

     // Start the recursion from index 0 with no ones or zeros used
     return DP(0, 0, 0);
 }
}