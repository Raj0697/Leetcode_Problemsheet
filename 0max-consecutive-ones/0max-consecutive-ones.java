class Solution {
    public int findMaxConsecutiveOnes(int[] nums) {
        int count=0, n=nums.length, max=0;
        for(int i=0; i<n; i++) {
            if(nums[i] == 1) {
                count ++;
                max = Math.max(max,count);}
            else
                count = 0;
                //max = Math.max(max, count);
        }
        return max;
    }
}