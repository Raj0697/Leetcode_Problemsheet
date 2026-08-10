public class Solution {
    public string LongestPrefix(string s) {
        int n = s.Length;
        if (n <= 1) return "";
        int[] lps = new int[n];
        int len = 0;
        int i = 1;
        while (i < n) {
            if (s[i] == s[len]) {
                len++;
                lps[i] = len;
                i++;
            } else {
                if (len != 0) {
                    len = lps[len - 1];
                } else {
                    lps[i] = 0;
                    i++;}}}
        int longestLength = lps[n - 1];
        return s.Substring(0, longestLength);}}