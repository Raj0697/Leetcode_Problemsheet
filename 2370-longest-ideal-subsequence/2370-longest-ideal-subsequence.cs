public class Solution {
    public int LongestIdealString(string s, int k) {
        Dictionary<char, int> d = new ();
        
        int max = 0;
        for (int i = 0; i < s.Length; i++) {
            int longest = 0;
            for (int j = 0; j <= k; j++) {
                char preceding = (char)(s[i] - j), succeeding = (char)(s[i] + j);
                if (d.ContainsKey(preceding)) longest = Math.Max(longest, d[preceding]);
                if (d.ContainsKey(succeeding)) longest = Math.Max(longest, d[succeeding]);
            }
            
            int current = longest + 1;
            d[s[i]] = current;
            max = Math.Max(max, current);
        }
        
        return max;
    }
}