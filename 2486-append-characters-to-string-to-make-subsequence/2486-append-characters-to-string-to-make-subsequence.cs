public class Solution {
    public int AppendCharacters(string s, string t) {
        int sIndex = 0, tIndex = 0;
        int sLength = s.Length, tLength = t.Length;

        // Iterate through both strings
        while (sIndex < sLength && tIndex < tLength) {
            if (s[sIndex] == t[tIndex]) {
                // Move to the next character in t
                tIndex++;
            }
            // Always move to the next character in s
            sIndex++;
        }

        // The characters that need to be appended are the remaining characters in t
        return tLength - tIndex;
    }
}