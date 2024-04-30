public class Solution {
    public long WonderfulSubstrings(string word) {
        long result = 0;
        int[] count = new int[1024];
        count[0] = 1;
        int mask = 0;

        foreach (char c in word) {
            mask ^= 1 << (c - 'a');
            result += count[mask];
            for (int i = 0; i < 10; i++) {
                result += count[mask ^ (1 << i)];
            }
            count[mask]++;
        }

        return result;
    }
}