public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int count=0, n=nums.Length, max=0;
        for(int i=0; i<n; i++) {
            if(nums[i] == 1) {
                count ++;
                max = Math.Max(max,count);}
            else
                count = 0;
                //max = Math.max(max, count);
        }
        return max;
    }
}