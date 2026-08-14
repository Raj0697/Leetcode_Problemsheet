public class Solution {
    public int NumberOfGoodSubsets(int[] nums) {
        const int MOD = 1_000_000_007;
        int[] freq = new int[31];
        foreach (int num in nums) freq[num]++;

        int[] primes = new int[] {2,3,5,7,11,13,17,19,23,29};
        Dictionary<int, int> maskMap = new();
        for (int i = 2; i <= 30; i++) {
            int mask = 0;
            bool valid = true;
            for (int j = 0; j < primes.Length; j++) {
                int p = primes[j];
                if (i % (p * p) == 0) {
                    valid = false;
                    break;
                }
                if (i % p == 0) mask |= (1 << j);
            }
            if (valid) maskMap[i] = mask;
        }

        long[] dp = new long[1 << primes.Length];
        dp[0] = 1;

        foreach (var kv in maskMap) {
            int num = kv.Key, mask = kv.Value;
            for (int state = (1 << primes.Length) - 1; state >= 0; state--) {
                if ((state & mask) == 0) {
                    dp[state | mask] = (dp[state | mask] + dp[state] * freq[num]) % MOD;
                }
            }
        }

        long result = 0;
        for (int i = 1; i < dp.Length; i++) result = (result + dp[i]) % MOD;

        int ones = freq[1];
        long pow = 1;
        for (int i = 0; i < ones; i++) pow = (pow * 2) % MOD;

        return (int)(result * pow % MOD);
    }
}