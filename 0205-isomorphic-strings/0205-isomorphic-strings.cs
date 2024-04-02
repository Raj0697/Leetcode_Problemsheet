public class Solution {
    public bool IsIsomorphic(string s, string t) {
        var dict = new Dictionary<char, char>();
        for(int i = 0 ; i < s.Length; i++)
        {
            char ss = s[i];
            char st = t[i];
            if(dict.ContainsKey(ss))
            {
                if(st != dict[ss]) return false;
            } else 
            {
                if(dict.ContainsValue(st)) return false;
                dict.Add(ss, st);
            }
        }
        return true;
    }
}