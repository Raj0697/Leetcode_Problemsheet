public class Solution {
    private const int MOD = 1000000007;
    private List<int>[] preferredBy;
    private int[,] dp;
    private int allMask;

    public int NumberWays(IList<IList<int>> hats) {
        int n = hats.Count;
        allMask = (1 << n) - 1;

        // Invert mapping: for each hat, store list of people who like it
        preferredBy = new List<int>[41];
        for (int i = 0; i < 41; i++) preferredBy[i] = new List<int>();
        for (int person = 0; person < n; person++)
            foreach (int hat in hats[person])
                preferredBy[hat].Add(person);

        // Initialize DP table with -1
        dp = new int[41, 1 << n];
        for (int i = 0; i < 41; i++)
            for (int j = 0; j < (1 << n); j++)
                dp[i, j] = -1;

        return CountWays(1, 0);
    }

    private int CountWays(int hat, int mask) {
        if (hat > 40) return mask == allMask ? 1 : 0;
        if (dp[hat, mask] != -1) return dp[hat, mask];

        // Option 1: skip this hat
        int ans = CountWays(hat + 1, mask);

        // Option 2: assign this hat to someone who likes it and is unassigned
        foreach (int person in preferredBy[hat]) {
            if ((mask & (1 << person)) != 0) continue; // already assigned
            ans += CountWays(hat + 1, mask | (1 << person));
            ans %= MOD;
        }

        return dp[hat, mask] = ans;
    }
}