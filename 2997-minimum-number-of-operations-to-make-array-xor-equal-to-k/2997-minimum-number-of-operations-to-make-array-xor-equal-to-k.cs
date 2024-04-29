public class Solution {
    public int MinOperations(int[] nums, int k) {
        int operations = 0;
        int xor = 0;
        foreach (var num in nums) {
            xor ^= num;
        }
        
        if (xor == k) {
            return 0;
        }
        
        int target = xor ^ k;
        while (target > 0) {
            operations++;
            target &= (target - 1);
        }
        return operations;
    }
}