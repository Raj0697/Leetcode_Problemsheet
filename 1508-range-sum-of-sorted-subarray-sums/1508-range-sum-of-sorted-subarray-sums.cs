public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        var size = n * (n + 1) / 2;
	var sums = new int[size];
	var k = 0;
	for (var i = 0; i < n; i++) {
		var sum = 0;
		for (var j = i; j < n; j++) {
			sum += nums[j];
			sums[k++] = sum;
		}
	}
	Array.Sort(sums);
	return (int)(
		sums.Skip(left - 1)
			.Take(right - left + 1)
			.Select(x => (long)x)
			.Sum() % (1_000_000_000 + 7)
	);
    }
}