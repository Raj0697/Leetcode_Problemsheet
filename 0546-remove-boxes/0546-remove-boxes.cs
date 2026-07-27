public class Solution {
    private int[,,] memo;
    private int[] boxes;

    public int RemoveBoxes(int[] boxes) {
        this.boxes = boxes;
        int n = boxes.Length;
        memo = new int[n, n, n];
        return DP(0, n - 1, 0);
    }

    private int DP(int l, int r, int k) {
        if (l > r) return 0;
        if (memo[l, r, k] != 0) return memo[l, r, k];

        // Optimization: merge consecutive same-color boxes at the start
        int origL = l, origK = k;
        while (l + 1 <= r && boxes[l] == boxes[l + 1]) {
            l++;
            k++;
        }

        // Option 1: remove current block immediately
        int res = (k + 1) * (k + 1) + DP(l + 1, r, 0);

        // Option 2: try merging with later same-color boxes
        for (int i = l + 1; i <= r; i++) {
            if (boxes[i] == boxes[l]) {
                res = Math.Max(res, DP(l + 1, i - 1, 0) + DP(i, r, k + 1));
            }
        }

        memo[origL, r, origK] = res;
        return res;
    }
}