class Solution {
    public int[] searchRange(int[] nums, int target) {
        int start = 0, end = nums.length - 1;
        int[]res={-1,-1};
        res[0] = searchFrom(nums,target,true);
        res[1] = searchFrom(nums,target,false);
        return res;
    }
    
    static int searchFrom(int[] nums, int target,boolean fromStart){
        int start = 0,end = nums.length-1;
        int ans = -1;
        while(start<=end){
            int mid = start + (end-start)/2;
            if(nums[mid]>target){
                end = mid-1;
            }else if(nums[mid]<target){
                start = mid+1;
            }else if(nums[mid]==target){
                ans = mid;  //potential answer
                //to search first and last occurance if element is found
				//first occurance
                if(fromStart){
                    end = mid-1;
                }else{ //last occurance
                    start = mid+1;
                }
            }
        }
        return ans;
    }
}

// while(l <= r){
//             m = l + (r-l)/2;    
//             if(nums[m] == target) {
//                 int i = m, j = m;
//                 while(i <= r && nums[i] == target) i++;
//                 while(j >= l && nums[j] == target) j--;
//                 return {j+1, i-1};
//             }
//             else if(target > nums[m]) l = m+1;
//             else r = m-1;
//         }