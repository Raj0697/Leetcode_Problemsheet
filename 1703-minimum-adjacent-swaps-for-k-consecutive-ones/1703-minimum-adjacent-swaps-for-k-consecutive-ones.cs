public class Solution {
    public int MinMoves(int[] nums, int k) {
        var prefix = new List<int>();
        int n = nums.Length;
        prefix.Add(0);

        for (int i = 0; i < n; i++) {
            if (nums[i] == 1) {
                prefix.Add(prefix.Last() + i);
            }
        }

        int res = Int32.MaxValue;

        for (int i = 0; i < prefix.Count - k; i++) {
            res = Math.Min(res,
                prefix[i + k] + prefix[i]
                - prefix[i + (k + 1) / 2]
                - prefix[i + k / 2]
                - (k / 2) * ((k + 1) / 2)
            );
        }

        return res;
    }
}