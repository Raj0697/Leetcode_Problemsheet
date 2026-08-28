public class Solution {
    public int CountSubarrays(int[] nums, int k) {
        int idxK = 0, n = nums.Length;
        // Time O(idxK)
        for (; idxK < n; idxK++) if (nums[idxK] == k) break;

        // Space O(2n+1)
        int[] leftBalanceCounts = new int[2 * n + 1];
        leftBalanceCounts[n] = 1;

        int currentBalance = 0;
        // Time O(idxK-1)
        for (int i = idxK - 1; i >= 0; i--) {
            if (nums[i] > k) currentBalance++;
            else if (nums[i] < k) currentBalance--;

            leftBalanceCounts[currentBalance + n]++;
        }

        int ret = 0;
        currentBalance = 0;
        // Time O(n-idxK)
        for (int i = idxK; i < n; i++) {
            if (nums[i] > k) currentBalance++;
            else if (nums[i] < k) currentBalance--;
            
            ret += leftBalanceCounts[0 - currentBalance + n];
            ret += leftBalanceCounts[1 - currentBalance + n];
        }
        
        return ret;
    }
}