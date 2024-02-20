using System.Text.RegularExpressions;
public class Solution {
    public bool IsMatch(string s, string p) {
        bool[,] dp = new bool[p.Length+1, s.Length+1];
        dp[0,0] = true;
        
        for(int i=0, x=1; i < p.Length; i++, x++)
        {
            if (p[i] == '*') { dp[x,0] = dp[x-2, 0]; }
            
            for(int j=0, y=1; j < s.Length; j++, y++)
            {
                if (p[i] == '*')
                {
                    dp[x,y] = dp[x-1,y] || dp[x-2, y] || (dp[x, y-1] && (p[i-1] == s[j] || p[i-1] == '.'));
                }
                else  if (p[i] == s[j] || p[i] == '.')
                {
                     dp[x,y] = dp[x-1, y-1];
                }
            }
        }
        
        return dp[p.Length, s.Length];
    }
}