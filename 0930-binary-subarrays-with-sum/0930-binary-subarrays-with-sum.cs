public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        int i = 0, j = 0, sum = 0, res = 0;

        while(j < nums.Length){
            while(j < nums.Length && sum < goal){
                sum += nums[j++];
            }

            int left = 1, right = 1;
            
            while(j < nums.Length && nums[j] == 0){
                right++;
                j++;
            }

            while(i < j && nums[i] == 0){
                left++;
                i++;
            }

            if(sum != goal)
                continue;

            if(i == j){
                res += left*(left-1)/2;
            }
            else{
                res += left*right;
            }

            if(i < nums.Length)
                sum -= nums[i++];
        }

        return res;
    }
}