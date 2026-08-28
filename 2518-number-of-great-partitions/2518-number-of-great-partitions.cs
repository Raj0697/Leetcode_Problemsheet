public class Solution {
    private const int Mod = 1000000007;

    public int CountPartitions(int[] nums, int k) {
        int f = 1, n = nums.Length, t = 0;

        // Use dp to compute how many subsequences of nums have a sum of 0 ~ k - 1
        int[] counts = new int[k];
        long s = 0;
        counts[0] = 1;

        foreach (int num in nums) {
            s += num;

            // Recursive formula: counts[i][j] = counts[i - 1][j] (subsequences of sum j that end before i) 
            // + counts[i - 1][j - num] (subsequences of sum j that ends at i)
            // I'm using a 1-D array for space optimization
            for (int i = k - 1; i >= num; i--) {
                counts[i] = (counts[i] + counts[i - num]) % Mod;
            }
        }

        // If the sum of all elements is less than k * 2, then surely the answer is 0
        // This is necessary because if s < k * 2, there will be subsequences whose counterparts are also counted in the dp.
        // This will mess up the result later on.
        if (s < k * 2) return 0;
        
        // Consider only one group for now because the other group will automatically be made up by whatever is excluded from it.
        // The group shall not include any of the subsequences whose sum is 0 ~ k - 1;
        foreach (var c in counts) {
            t = (t + c) % Mod;
        }
        
        // Double the total because we do not want the counterpart of those subsequences
        // If s < k * 2, the total count will be great because the total number of subsequences of nums will be 
        // counted twice, which is not correct.
        t = (t * 2) % Mod;
        
        // The total number of subsequences of nums is 2^n where n is the length of nums
        for (int i = 0; i < n; i++) {
            f = (f * 2) % Mod;
        }

        return (1000000007 + f - t) % Mod;
    }
}