public class Solution {
    public int ArraySign(int[] nums) {
        //return nums.Any(x => x== 0) ? 0: nums.Count( a => a < 0) % 2 == 1 ? -1 :1;
        int minus = 0;
        foreach(int i in nums) {
            if(i == 0)
                return 0;
            if(i < 0)
                minus++;
        }
        return minus%2 == 0 ? 1 : -1;
    }
}