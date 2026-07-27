public class Solution {
    public bool SplitArraySameAverage(int[] nums) {
        int n = nums.Length;
        int sum = nums.Sum();

        // Early pruning
        bool possible = false;
        for (int k = 1; k <= n / 2; k++) {
            if ((sum * k) % n == 0) {
                possible = true;
                break;
            }
        }
        if (!possible) return false;

        // DP: dp[k] = set of possible sums with k elements
        var dp = new HashSet<int>[n + 1];
        for (int i = 0; i <= n; i++) dp[i] = new HashSet<int>();
        dp[0].Add(0);

        foreach (int num in nums) {
            for (int k = n - 1; k >= 0; k--) {
                foreach (int s in dp[k]) {
                    dp[k + 1].Add(s + num);
                }
            }
        }

        for (int k = 1; k <= n / 2; k++) {
            if ((sum * k) % n == 0) {
                int target = (sum * k) / n;
                if (dp[k].Contains(target)) return true;
            }
        }
        return false;
    }
}