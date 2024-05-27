public class Solution {
    public int SpecialArray(int[] nums) {
        Array.Sort(nums);
        for(int i=0; i<nums.Length; i++){
            int n = nums.Length-i;
            bool cond1 = n<=nums[i];
            bool cond2 = (i-1<0) || (n>nums[i-1]);
            if(cond1 && cond2) return n;
        }
        return -1;
    }
}