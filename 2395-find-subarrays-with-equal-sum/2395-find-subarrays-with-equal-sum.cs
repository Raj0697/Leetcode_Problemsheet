public class Solution {
    public bool FindSubarrays(int[] nums) {
        HashSet<int> sum = new HashSet<int>();
        
        for (int j = 0; j < nums.Length - 1; j++) {
            int val = nums[j] + nums[j + 1];
            if (sum.Contains(val)) {
                return true;
            } else {
                sum.Add(val);
            }
        }

        return false;
    }
}