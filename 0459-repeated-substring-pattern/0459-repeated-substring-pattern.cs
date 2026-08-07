public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        int n = s.Length;
    
        for (int len = 1; len <= n / 2; len++) {
            if (n % len == 0) {
                string sub = s.Substring(0, len);
                StringBuilder sb = new StringBuilder();
                
                for (int i = 0; i < n / len; i++) {
                    sb.Append(sub);
                }
                
                if (sb.ToString() == s) {
                    return true;
                }
            }
        }
        
        return false;
    }
}