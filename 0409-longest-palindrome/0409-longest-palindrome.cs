public class Solution {
    public int LongestPalindrome(string s) {
        var set = new HashSet<char>();
        var maxLength = 0;

        foreach (var c in s)
        {
            if (set.Contains(c))
            {
                set.Remove(c);
                maxLength += 2;
            }
            else
                set.Add(c);
        }

        return set.Count > 0 ? maxLength + 1 : maxLength;
    }
}