public class Solution
{
    const int MOD = 1000000007;
    long[,,] dp = new long[23, 401, 2];

    public Solution()
    {
        // Initialize dp array with -1
        for (int i = 0; i < 23; i++)
        {
            for (int j = 0; j < 401; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    dp[i, j, k] = -1;
                }
            }
        }
    }

    // Recursive function to solve the problem using memoization
    private long Solve(int idx, int sum, bool tight, int minSum, int maxSum, string s)
    {
        if (idx == s.Length)
        {
            return sum >= minSum && sum <= maxSum ? 1 : 0;
        }

        if (dp[idx, sum, tight ? 1 : 0] != -1)
        {
            return dp[idx, sum, tight ? 1 : 0];
        }

        long ans = 0;
        if (tight)
        {
            // When we are still tight to the current number's digits, explore all possibilities up to the digit
            for (int i = 0; i <= s[idx] - '0'; i++)
            {
                ans = (ans + Solve(idx + 1, sum + i, (s[idx] - '0') == i, minSum, maxSum, s)) % MOD;
            }
        }
        else
        {
            // When we are not tight, we can freely choose any digit from 0 to 9
            for (int i = 0; i <= 9; i++)
            {
                ans = (ans + Solve(idx + 1, sum + i, false, minSum, maxSum, s)) % MOD;
            }
        }

        dp[idx, sum, tight ? 1 : 0] = ans;
        return ans;
    }

    // Main function to count the valid numbers between num1 and num2
    public int Count(string num1, string num2, int minSum, int maxSum)
    {
        // Calculate the number of valid numbers less than or equal to num2
        long upper = Solve(0, 0, true, minSum, maxSum, num2);

        // Reinitialize dp for lower bound calculation
        for (int i = 0; i < 23; i++)
        {
            for (int j = 0; j < 401; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    dp[i, j, k] = -1;
                }
            }
        }

        // Calculate the number of valid numbers less than num1
        long lower = Solve(0, 0, true, minSum, maxSum, num1);

        // Calculate sum of digits for num1
        int sum = 0;
        foreach (var c in num1)
        {
            sum += c - '0';
        }

        if (sum >= minSum && sum <= maxSum)
        {
            lower--; // Subtract 1 if num1 itself is within the range
        }

        // Return the result modulo MOD
        return (int)((upper - lower + MOD) % MOD);
    }
}