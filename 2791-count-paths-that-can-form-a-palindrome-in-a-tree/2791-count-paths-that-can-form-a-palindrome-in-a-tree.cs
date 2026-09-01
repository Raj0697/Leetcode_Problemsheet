public class Solution {
    
    private Dictionary<int, long> freq = new Dictionary<int, long>();
    private int M = int.MaxValue;

    public long CountPalindromePaths(IList<int> parent, string s) {
        int n = parent.Count;
        int[] dp = new int[n];
        Array.Fill(dp, M);
        long ans = 0;

        // Iterate over each node in the tree
        for (int i = 0; i < parent.Count; i++) {
            int mask = F(i, parent, s, dp);  // Get mask from root to current node
            // Check for the palindrome paths by flipping each bit in the mask
            for (int j = 0; j < 26; j++) {
                int mask_ = mask ^ (1 << j);  // mask_ is a 1-bit difference from mask
                if (freq.ContainsKey(mask_)) {
                    ans += freq[mask_];
                }
            }
            // Add paths where there is no bit difference
            if (freq.ContainsKey(mask)) {
                ans += freq[mask];
            }
            // Increment the frequency of the current mask
            if (!freq.ContainsKey(mask)) {
                freq[mask] = 0;
            }
            freq[mask]++;
        }

        return ans;
    }

    private int F(int idx, IList<int> li, string s, int[] dp) {
        int c = idx, p = li[idx];
        if (p == -1) return 0;
        if (dp[c] != M) return dp[c];

        int mask = 1 << (s[c] - 'a');
        dp[c] = mask;
        dp[c] ^= F(p, li, s, dp);  // XOR with the mask of (parent to root)
        return dp[c];
    }
}