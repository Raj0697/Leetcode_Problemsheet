public class Solution {
    public int[] SingleNumber(int[] nums) {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        // Step 1: Count frequencies
        foreach (int num in nums) {
            if (frequency.ContainsKey(num)) {
                frequency[num]++;
            } else {
                frequency[num] = 1;
            }
        }

        // Step 2: Find the two numbers that appear only once
        List<int> result = new List<int>();
        foreach (var pair in frequency) {
            if (pair.Value == 1) {
                result.Add(pair.Key);
            }
        }

        return result.ToArray();
    }
}