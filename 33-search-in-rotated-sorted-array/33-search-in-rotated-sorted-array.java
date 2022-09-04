class Solution {
    public int search(int[] nums, int target) {
        /*
        1. Using binary search as we need solution on O(logN)
        */
        int n = nums.length;
        
        int low = 0;
        int high = n-1;
        
        while(low <= high){
            int mid = (low + high)/2;
            //check if mid is the target
            if(nums[mid] == target)
                return mid;
            //check if left side is sorted by checking if low is less that mid
            if(nums[low] <= nums[mid]){
                // that means look at left side
                if(target >= nums[low] && target < nums[mid]){
                    high = mid-1;
                }else{
                    low = mid + 1;
                }
            }else{
                //that means look at right side
                if(target > nums[mid] && target <= nums[high]){
                    low = mid +1;   
                }else{
                    high = mid - 1;
                }
            }
        }
        
        return -1;
    }
}