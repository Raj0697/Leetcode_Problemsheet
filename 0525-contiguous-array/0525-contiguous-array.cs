public class Solution {
    public int FindMaxLength(int[] nums) {
        var dict = new Dictionary<int,int>();
        int diff = 0;
        int maxLen = 0;
        
        dict.Add(0, -1);
        for (int i = 0; i < nums.Length; i++) {
            diff += (nums[i] == 1 ? 1 : -1);
            if (dict.ContainsKey(diff))
                maxLen = Math.Max(maxLen, i - dict[diff]);
            else
                dict.Add(diff, i);
        }
        
        return maxLen;
    }
}