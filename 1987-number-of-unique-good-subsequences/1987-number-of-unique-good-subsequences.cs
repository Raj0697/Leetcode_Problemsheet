public class Solution {
    public int NumberOfUniqueGoodSubsequences(string binary) {
        int MOD = 1_000_000_007;
        long endWith0 = 0, endWith1 = 0;
        bool hasZero = false;

        foreach (char c in binary) {
            if (c == '0') {
                hasZero = true;
                endWith0 = (endWith0 + endWith1) % MOD;
            } else {
                endWith1 = (endWith0 + endWith1 + 1) % MOD;
            }
        }

        return (int)((endWith0 + endWith1 + (hasZero ? 1 : 0)) % MOD);
    }
}