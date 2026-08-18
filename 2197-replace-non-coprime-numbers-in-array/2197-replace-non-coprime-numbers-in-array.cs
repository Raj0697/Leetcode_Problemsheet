public class Solution {
    public IList<int> ReplaceNonCoprimes(int[] nums) {
         List<int> stack = new List<int>();
        
        foreach (int num in nums) {
            long curr = num; // use long to prevent overflow during LCM
            
            // Keep merging while stack top and current number are non-coprime
            while (stack.Count > 0) {
                int top = stack[stack.Count - 1];
                int g = GCD(top, (int)curr);
                if (g == 1) break; // coprime, stop merging
                
                stack.RemoveAt(stack.Count - 1);
                curr = LCM(top, (int)curr, g);
            }
            
            stack.Add((int)curr);
        }
        
        return stack;
    }
    private int GCD(int a, int b) {
        while (b != 0) {
            int temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }
    
    private long LCM(int a, int b, int g) {
        // LCM = (a / gcd) * b
        return (long)a / g * b;
    }
}