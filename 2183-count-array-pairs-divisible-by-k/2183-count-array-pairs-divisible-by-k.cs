public class Solution {
    public long CountPairs(int[] nums, int k) {
        Dictionary<int, int> gcdCount = new();
        long res = 0;

        foreach (int num in nums) {
            int g = GCD(num, k);
            foreach (var kvp in gcdCount) {
                if ((long)g * kvp.Key % k == 0) {
                    res += kvp.Value;
                }
            }
            if (!gcdCount.ContainsKey(g)) gcdCount[g] = 0;
            gcdCount[g]++;
        }

        return res;
    }

    private int GCD(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}