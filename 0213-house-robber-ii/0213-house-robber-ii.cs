public class Solution {
    public int Rob(int[] nums) {
            if (nums.Length == 0)
            return 0;
        else if (nums.Length == 1)
            return nums[0];
        else
            return Math.Max(robRange(nums, 0, nums.Length - 2), robRange(nums, 1, nums.Length - 1));
    }
       private int robRange(int[] num, int start, int end)
    {
        int with = num[start];
        int without = 0;
        for (int i = start + 1; i <= end; i++)
        {
            int newWith = without + num[i];
            int newWithout = Math.Max(with, without);
            with = newWith;
            without = newWithout;
        }
        return Math.Max(with, without);
    }
}