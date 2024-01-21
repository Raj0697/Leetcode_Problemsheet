public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length == 0)
            return 0;
        
        int[,] res = new int[2, nums.Length];
        
        res[0, 0] = 0;
        res[1, 0] = nums[0];
        
        for (int i = 1; i < nums.Length; i++)
        {
            res[0, i] = Math.Max(res[0, i - 1], res[1, i - 1]);
            res[1, i] = res[0, i - 1] + nums[i];
        }
        
        return Math.Max(res[0, nums.Length - 1], res[1, nums.Length - 1]);
    }
}