public class Solution {
    public int MaxOperations(int[] nums, int k) {
        Array.Sort(nums);
        int ans = 0;
        int i = 0, j = nums.Length - 1;
        while (i < j) {
            int temp = nums[i] + nums[j];
            if (temp == k) {
                i++;
                j--;
                ans++;
            } else if (temp > k) {
                j--;
            } else {
                i++;
            }
        }
        return ans;
    }
}