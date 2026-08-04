public class Solution {
    public int BestRotation(int[] nums) {
        var n = nums.Length;
        var sweepline = new int[n + 1];
        for (var i = 0; i < n; i += 1)
        {
            var num = nums[i];
            if (i >= num)
            {
                var start = 0;
                var end = i - num;
                sweepline[start] += 1;
                sweepline[end + 1] -= 1;
                start = i + 1;
                end = n - 1;
                if (start <= end)
                {
                    sweepline[start] += 1;
                    sweepline[end + 1] -= 1;
                }
            }
            else
            {
                var start = i + 1;
                var end = start + (n - num - 1);
                sweepline[start] += 1;
                sweepline[end + 1] -= 1;
            }
        }
        var max = 0;
        var overlaps = 0;
        var k = 0;
        for (var i = 0; i < n; i += 1)
        {
            overlaps += sweepline[i];
            if (overlaps > max)
            {
                max = overlaps;
                k = i;
            }
        }
        return k;
    }
}