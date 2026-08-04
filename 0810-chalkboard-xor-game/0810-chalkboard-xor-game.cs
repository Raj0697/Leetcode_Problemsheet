public class Solution {
    public bool XorGame(int[] nums) {
        int xor = 0;
        foreach (var x in nums) xor ^= x;
        if (xor == 0) return true;
        return (nums.Length % 2 == 0);
    }
}