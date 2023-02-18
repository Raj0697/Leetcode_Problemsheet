class Solution {
    public int maximumCount(int[] nums) {
        int neg = binary(nums, 0), pos = nums.length - binary(nums, 1);
        return Math.max(neg,pos);
    }
    
    public static int binary(int[] nums, int k) {
        int start = 0, end = nums.length;
        while(start < end) {
            int mid = start + (end-start)/2;
            if(nums[mid] < k)
                start = mid+1;
            else
                end = mid;
        }
        return start;
    }
}