public class Solution
{
    private readonly Dictionary<int, int> memo = new Dictionary<int, int>();

    public int LeastOpsExpressTarget(int x, int target)
    {
        if (target < x) return Math.Min(2 * target - 1, 2 * (x - target)); // Base case for small targets
        if (memo.ContainsKey(target)) return memo[target];

        long prod = x;
        int n = 0;

        // Find the smallest power of x that exceeds or equals the target
        while (prod < target)
        {
            prod *= x;
            n++;
        }

        // If target is exactly a power of x, we need n operators (multiplications)
        if (prod == target)
        {
            memo[target] = n;
            return n;
        }

        // Try subtracting the nearest lower power of x
        int subtractOption = LeastOpsExpressTarget(x, target - (int)(prod / x)) + n;

        // Try adding to the nearest higher power of x
        int addOption = int.MaxValue;
        if (prod - target < target)
        {
            addOption = LeastOpsExpressTarget(x, (int)(prod - target)) + n + 1;
        }

        // Memoize and return the minimum of both options
        int result = Math.Min(subtractOption, addOption);
        memo[target] = result;

        return result;
    }
}