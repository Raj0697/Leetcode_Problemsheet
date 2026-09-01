public class Solution {
    public int SumOfPower(int[] nums) {
        const int Mod = 1000000007; // Modulo value to avoid overflow
        Array.Sort(nums); // Sort the array to process in increasing order
        
        long prev = 0, sum = 0; // Use long to avoid overflow during calculation
        
        foreach (var n in nums) {
            sum = (sum + ((long)n * n % Mod) * ((prev + n) % Mod) % Mod) % Mod; // Update sum with the current value
            prev = (prev * 2 + n) % Mod; // Update prev for the next iteration
        }
        
        return (int)sum; // Cast the result to int before returning
    }
}