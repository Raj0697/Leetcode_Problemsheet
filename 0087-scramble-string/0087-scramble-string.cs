public class Solution {
    public bool IsScramble(string s1, string s2) 
    {
        Dictionary<(int, int, int), bool> dp = new();
        return IsScramble(0, 0, s1.Length);
        
        bool IsScramble(int f, int s, int len) 
        {
            if (dp.ContainsKey((f, s, len))) return dp[(f, s, len)];
            if (len == 1) return s1[f] == s2[s];            
            
            bool res = false;
            for (int i = 1; i < len; ++i) 
                res |= (IsScramble(f, s, i) && IsScramble(f + i, s + i, len - i)) || 
                        (IsScramble(f, s + len - i, i) && IsScramble(f + i, s, len - i));
            dp.Add((f, s, len), res);
            return res;
        }
    }
}