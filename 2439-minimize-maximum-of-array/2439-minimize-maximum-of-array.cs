public class Solution {
    public int MinimizeArrayValue(int[] nums)
    {
        int result = 0;
        int low = nums.Min();
        int high = nums.Max();

        while (low <= high)
        {
            long mid = ((long)low + (long)high) / 2;

            if (isValidMid(nums, mid))
            {
                result = (int)mid;
                high = result - 1;
            }
            else
            {
                low = (int)mid + 1;
            }
        }
        return result;
    }

    private bool isValidMid(int[] nums, long mid)
    {
        long tempRem = 0;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] <= mid)
            {
                tempRem -= Math.Min(tempRem, mid - nums[i]);
            }
            else
            {
                tempRem += nums[i] - mid;
            }
        }
        return tempRem <= 0;
    }
}