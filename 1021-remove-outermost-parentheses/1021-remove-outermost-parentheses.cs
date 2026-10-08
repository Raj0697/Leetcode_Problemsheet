public class Solution {
    public string RemoveOuterParentheses(string s) {
                if (s.Length <= 2) return string.Empty;

        var sb = new StringBuilder();
        var count = 0;
        var start = 0;

        for (int i = 0; i < s.Length; i++)
        {
            count += s[i] == '(' ? 1 : -1;
            if (count == 0)
            {
                if (i - start - 1 > 0)
                    sb.Append(s.Substring(start + 1, i - start - 1));
                start = i + 1;
            }
        }

        return sb.ToString();
    }
}