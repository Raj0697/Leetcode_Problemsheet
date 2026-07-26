public class Solution {
    public int FindKthNumber(int n, int k) {
        int current = 1;
        k--;

        while (k > 0) {
            long steps = CountSteps(n, current, current + 1);
            if (steps <= k) {
                current++;
                k -= (int)steps;
            } else {
                current *= 10;
                k--;
            }
        }

        return current;
    }

    private long CountSteps(int n, long curr, long next) {
        long steps = 0;
        while (curr <= n) {
            steps += Math.Min(n + 1, next) - curr;
            curr *= 10;
            next *= 10;
        }
        return steps;
    }
}