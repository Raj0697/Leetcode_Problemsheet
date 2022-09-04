class Solution {
    int min = Integer.MAX_VALUE;
    
    public int findMin(int[] nums) {
        binarySearch(nums, 0, nums.length-1);
        
        return min;
    }
    
    void binarySearch(int[] nums, int l, int r) {
        if (l > r) return;
        
        int mid = (r-l)/2 + l;
        int val = nums[mid];
        
        min = Math.min(min, val);
        
        // Left Sorted
        if (nums[l] <= val) {
            if (nums[l] < min && nums[r] > min)
                binarySearch(nums, l, mid-1);
            else
                binarySearch(nums, mid+1, r);
        }
        // Right Sorted
        else if (val < nums[r]) {
            if (nums[r] < min)
                binarySearch(nums, mid+1, r);
            else
                binarySearch(nums, l, mid-1);
        }
    }
}