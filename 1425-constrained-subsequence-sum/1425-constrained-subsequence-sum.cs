public class Solution {
    public int ConstrainedSubsetSum(int[] nums, int k) {
        int n = nums.Length;
        int[] dp = new int[n];
        LinkedList<int> deque = new LinkedList<int>();
        int res = nums[0];
        dp[0] = nums[0];
        deque.AddLast(0);

        for (int i = 1; i < n; i++) {
            if (deque.First.Value < i - k)
                deque.RemoveFirst();

            dp[i] = nums[i] + Math.Max(0, dp[deque.First.Value]);
            res = Math.Max(res, dp[i]);

            while (deque.Count > 0 && dp[i] >= dp[deque.Last.Value])
                deque.RemoveLast();

            deque.AddLast(i);
        }

        return res;
    }
}