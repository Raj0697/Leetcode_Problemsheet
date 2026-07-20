public class Solution {
    public int LongestSubarray(int[] nums) {
        int zeroCount = 0;
        int longestWindow = 0;
        int start = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            zeroCount += (nums[i] == 0 ? 1 : 0);

            while (zeroCount > 1)
            {
                zeroCount -= (nums[start] == 0 ? 1 : 0);
                start++;
            }

            longestWindow = Math.Max(longestWindow, i - start);
        }

        return longestWindow;
    }
}