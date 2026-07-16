public class Solution {
    public int LongestOnes(int[] nums, int k) {
        int i = 0, j = 0;
        while (j < nums.Length) {
            if (nums[j++] == 0) {
                k--;
            }
            if (k < 0) {
                if (nums[i++] == 0) {
                    k++;
                }
            }
        }
        return j - i;
    }
}