public class Solution {
    public string LastSubstring(string s) {
        int n = s.Length;
        int i = 0, j = 1, k = 0;

        while (j + k < n) {
            if (s[i + k] == s[j + k]) {
                k++;
            } else if (s[i + k] > s[j + k]) {
                j = j + k + 1;
                k = 0;
            } else {
                i = Math.Max(i + k + 1, j);
                j = i + 1;
                k = 0;
            }
        }

        return s.Substring(i);
    }
}