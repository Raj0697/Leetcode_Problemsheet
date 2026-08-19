public class Solution {
    public long CountSubarrays(int[] nums, long k) {
        
        int left = 0, right = 0;
        long result = 0, sum = 0;

        while(right < nums.Length)
        {
            sum += nums[right];
            right++;

            while(sum * (right - left) >= k)
            {
                sum -= nums[left];
                left++;
            }

            result += right - left;
        }

        return result;
    }
}