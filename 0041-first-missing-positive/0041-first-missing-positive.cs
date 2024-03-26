public class Solution {
    public int FirstMissingPositive(int[] nums) {
        Array.Sort(nums);
        int ct = nums.Length;
        HashSet<int> arr = new HashSet<int>(nums);
        for(int i = 1;i<=nums.Length;i++)
        {
            if(!arr.Contains(i))
            {
                return i;
            }else if(!arr.Contains(i+1)){
                return i+1;
            }
        }
        return ct;
    }
}