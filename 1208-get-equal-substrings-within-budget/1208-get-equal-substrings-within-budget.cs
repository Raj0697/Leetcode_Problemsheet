public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        int cost = 0, start = 0, end = 0;
        while (end < s.Length) {
            cost += Math.Abs(s[end] - t[end]);
            if (cost > maxCost) {
                cost -= Math.Abs(s[start] - t[start]);
                start++;
            }
            
            end++;
        }
        
        return end - start;
    }
}