public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        var odds = new List<int>();
	for (var i = 0; i < nums.Length; i++) {
		if (nums[i] % 2 == 1) {
			odds.Add(i);
		}
	}

	var n = odds.Count;
	if (n < k) {
		return 0;
	}

	var count = 0;
	for (var i = 0; i < n - k + 1; i++) {
		var left = i == 0 ? odds[0] + 1 : odds[i] - odds[i - 1];
		var right = i == n - k ? nums.Length - odds[n - 1] : odds[i + k] - odds[i + k - 1];
		count += left * right;
	}

	return count;
    }
}