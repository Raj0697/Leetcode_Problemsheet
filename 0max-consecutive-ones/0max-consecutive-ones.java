class Solution {
    public int findMaxConsecutiveOnes(int[] nums) {
        int count=0, n=nums.length, max=0;
        for(int i=0; i<n; i++) {
            count += nums[i];
            if(nums[i] == 0)
                count = 0;
            else
                max = Math.max(max, count);
        }
        return max;
    }
}