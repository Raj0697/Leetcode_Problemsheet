class Solution {
    public int[] buildArray(int[] nums) {
        int[] ans = new int[nums.length];
        for(int i : nums){
            int n = nums[i];
            ans[i] = nums[n];
        }
        return ans;
    }
}