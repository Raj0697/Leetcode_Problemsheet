public class Solution {
    public int MinimumLength(string s) {
        int length = s.Length;

        if (length <= 1) {
            return length;
        }

        int left = 0, right = length - 1;

        while (left < right && s[left] == s[right]) {
            char ch = s[left];

            // Find the non-empty prefix
            while (left <= right && s[left] == ch) {
                left++;
            }

            // Find the non-empty suffix
            while (left <= right && s[right] == ch) {
                right--;
            }
        }

        return right - left + 1;
    }
}