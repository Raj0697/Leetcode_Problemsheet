public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length < 2) {
            return s;
        }
        int start = 0;
        int maxLength = 1;
        for (int i = 0; i < s.Length; i++) {
            int left = i;
            int right = i;
            while (left>=0 && right<s.Length && s[left]==s[right]){
                if (right - left + 1 > maxLength) {
                    start = left;
                    maxLength = right - left + 1;
                }
                left--;
                right++;
            }
            left = i;
            right = i + 1;
            while (left>=0 && right<s.Length && s[left]==s[right]){
                if (right - left + 1 > maxLength) {
                    start = left;
                    maxLength = right - left + 1;
                }
                left--;
                right++;
            }
        }
        return s.Substring(start, maxLength);    }
}