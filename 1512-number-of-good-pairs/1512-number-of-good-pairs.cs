public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        int res = 0;
        int[] count = new int[101];
        foreach(int a in nums) {
            res += count[a]++;
        }
        return res;
    }
}