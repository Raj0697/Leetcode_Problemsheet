public class Solution {
    const int MOD = 1_000_000_007;
    public int IdealArrays(int n, int maxValue) {
        int maxLen = 14; 

        int[,] dp = new int[maxLen + 1, maxValue + 1];
        for (int j = 1; j <= maxValue; j++) {
            dp[1, j] = 1;
        }

        for (int len = 2; len <= maxLen; len++) {
            for (int val = 1; val <= maxValue; val++) {
                for (int k = 2 * val; k <= maxValue; k += val) {
                    dp[len, k] = (dp[len, k] + dp[len - 1, val]) % MOD;
                }
            }
        }
        long[] fact = new long[n + 1];
        long[] invFact = new long[n + 1];
        fact[0] = invFact[0] = 1;

        for (int i = 1; i <= n; i++) {
            fact[i] = (fact[i - 1] * i) % MOD;
        }

        invFact[n] = ModInverse(fact[n]);
        for (int i = n - 1; i >= 1; i--) {
            invFact[i] = (invFact[i + 1] * (i + 1)) % MOD;
        }

        long result = 0;

        for (int len = 1; len <= maxLen; len++) {
            long waysToPickPositions = Comb(n - 1, len - 1, fact, invFact);
            for (int val = 1; val <= maxValue; val++) {
                result = (result + (waysToPickPositions * dp[len, val]) % MOD) % MOD;
            }
        }

        return (int)result;
    }
    private long ModInverse(long x) {
        return Pow(x, MOD - 2);
    }

    private long Pow(long baseVal, long exp) {
        long result = 1;
        baseVal %= MOD;
        while (exp > 0) {
            if ((exp & 1) == 1)
                result = (result * baseVal) % MOD;
            baseVal = (baseVal * baseVal) % MOD;
            exp >>= 1;
        }
        return result;
    }

    private long Comb(int n, int k, long[] fact, long[] invFact) {
        if (k < 0 || k > n) return 0;
        return (((fact[n] * invFact[k]) % MOD) * invFact[n - k]) % MOD;
    }
}