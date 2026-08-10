public class Solution {
    const int MOD = 1_000_000_007;
    int[,,,,] dp;
    int[] pi;
    string s1, s2, evil;
    int n;

    public int FindGoodStrings(int n, string s1, string s2, string evil) {
        this.n = n;
        this.s1 = s1;
        this.s2 = s2;
        this.evil = evil;
        this.pi = BuildPrefixTable(evil);
        dp = new int[n + 1, evil.Length + 1, 2, 2, 2]; // pos, matched, tightLow, tightHigh, isEvilMatched
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= evil.Length; j++)
                for (int a = 0; a < 2; a++)
                    for (int b = 0; b < 2; b++)
                        for (int c = 0; c < 2; c++)
                            dp[i, j, a, b, c] = -1;

        return Dfs(0, 0, true, true, false);
    }

    int Dfs(int pos, int matched, bool tightLow, bool tightHigh, bool isEvilMatched) {
        if (isEvilMatched) return 0;
        if (pos == n) return 1;

        int tl = tightLow ? 1 : 0;
        int th = tightHigh ? 1 : 0;
        int ev = isEvilMatched ? 1 : 0;

        if (dp[pos, matched, tl, th, ev] != -1)
            return dp[pos, matched, tl, th, ev];

        char from = tightLow ? s1[pos] : 'a';
        char to = tightHigh ? s2[pos] : 'z';
        int res = 0;

        for (char ch = from; ch <= to; ch++) {
            int nextMatched = matched;
            
            while (nextMatched > 0 && ch != evil[nextMatched])
                nextMatched = pi[nextMatched - 1];
            if (ch == evil[nextMatched])
                nextMatched++;
            bool nextEvil = nextMatched == evil.Length;

            bool nextTightLow = tightLow && (ch == s1[pos]);
            bool nextTightHigh = tightHigh && (ch == s2[pos]);

            res = (res + Dfs(pos + 1, nextMatched, nextTightLow, nextTightHigh, nextEvil)) % MOD;
        }

        dp[pos, matched, tl, th, ev] = res;
        return res;
    }

    int[] BuildPrefixTable(string pattern) {
        int[] pi = new int[pattern.Length];
        for (int i = 1, j = 0; i < pattern.Length; i++) {
            while (j > 0 && pattern[i] != pattern[j])
                j = pi[j - 1];
            if (pattern[i] == pattern[j])
                j++;
            pi[i] = j;
        }
        return pi;
    }
}