public class Solution {
    public int MinimizeArrayValue(int[] nums)
    {
        long ans = 0;
        long sum = 0;
        for (var i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }

        for (var i = nums.Length-1; i >= 0; i--) {
            ans = Math.Max(ans, (long)Math.Ceiling(sum * 1.0 / (i+1)));
            sum -= nums[i];    
        }

        return (int)ans;
    }

//     private bool isValidMid(int[] nums, long mid)
//     {
//         long tempRem = 0;

//         for (int i = nums.Length - 1; i >= 0; i--)
//         {
//             if (nums[i] <= mid)
//             {
//                 tempRem -= Math.Min(tempRem, mid - nums[i]);
//             }
//             else
//             {
//                 tempRem += nums[i] - mid;
//             }
//         }
//         return tempRem <= 0;
//     }
}