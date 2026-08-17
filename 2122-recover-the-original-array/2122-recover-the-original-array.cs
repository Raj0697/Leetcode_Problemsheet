public class Solution {
    public int[] RecoverArray(int[] nums) {
        Array.Sort(nums);
        int n = nums.Length;

        for (int i = 1; i < n; i++) {
            // Calculate potential k
            int k = (nums[i] - nums[0]) % 2 == 1 ? -1 : (nums[i] - nums[0]) / 2;
            if (k <= 0) continue;

            var freqMap = new Dictionary<int, int>();
            var recoveredArray = new List<int>();

            foreach (var num in nums) {
                if (freqMap.TryGetValue(num, out int count) && count > 0) {
                    recoveredArray.Add(num - k);
                    freqMap[num]--;
                    if (freqMap[num] == 0) {
                        freqMap.Remove(num);
                    }
                } else {
                    freqMap[num + 2 * k] = freqMap.GetValueOrDefault(num + 2 * k, 0) + 1;
                }
            }

            if (recoveredArray.Count == n / 2 && freqMap.Count == 0) {
                return recoveredArray.ToArray();
            }
        }

        return Array.Empty<int>(); // Return an empty array if no valid solution is found
    }
}