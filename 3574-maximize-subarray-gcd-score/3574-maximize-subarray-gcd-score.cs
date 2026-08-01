public class Solution {
    public long MaxGCDScore(int[] nums, int k) {
        int GCD(int n1, int n2) {
            var r = n2 % n1;
            return r == 0 ? n1 : GCD(r, n1);
        }

        long maxScore = nums.Length;
        for (var start = 0; start < nums.Length; start++) {
            var gcd = nums[start];
            var double_gcd = 2 * gcd;
            var k_used = 0;
            for (var end = start; end < nums.Length; end++) {
                var new_gcd = GCD(gcd, nums[end]);
                if (new_gcd < gcd) {
                    if (gcd % (2 * new_gcd) == 0) {
                        k_used = 0;
                    }
                    gcd = new_gcd;
                    double_gcd = 2 * gcd;
                }

                if (nums[end] % double_gcd != 0) {
                    k_used++;
                }

                var score = (long)(end - start + 1) * gcd * (k_used <= k ? 2 : 1);
                if (score > maxScore) {
                    maxScore = score;
                } else {
                    var max_possible_score = (long)(nums.Length - start + 1) * gcd * (k_used <= k ? 2 : 1);
                    if (max_possible_score <= maxScore) {
                        break;
                    }
                }
            }
        }
        return maxScore;
    }
}