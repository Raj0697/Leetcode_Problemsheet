public class Solution {
    public int SingleNumber(int[] nums) {
        int ones = 0; // Tracks the bits that have appeared once
        int twos = 0; // Tracks the bits that have appeared twice
    
        foreach (int num in nums) 
        {
            ones = (ones ^ num) & ~twos;
            twos = (twos ^ num) & ~ones;
        }
        
        return ones;
    }
}