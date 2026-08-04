public class Solution {
    public int UniqueLetterString(string s) {
        int n = s.Length;
        var lastSeen = new Dictionary<char, int>();
        var nextSeen = new int[n];

        // Precompute next occurrence for each position
        var nextOcc = new Dictionary<char, int>();
        for (int i = n - 1; i >= 0; i--) {
            char c = s[i];
            nextSeen[i] = nextOcc.GetValueOrDefault(c, n);
            nextOcc[c] = i;
        }

        long res = 0;
        int prev = -1;

        for (int i = 0; i < n; i++) {
            char c = s[i];

            // Left: previous occurrence (or -1)
            prev = lastSeen.GetValueOrDefault(c, -1);

            // Right: next occurrence (or n)
            int next = nextSeen[i];

            // Contribution: (i - prev) * (next - i)
            res += (i - prev) * (next - i);
            lastSeen[c] = i;
        }

        return (int)res;
    }
}