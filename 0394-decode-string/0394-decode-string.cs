public class Solution {
    public string DecodeString(string s) 
    {
        var repeat = 0;
        var sb = new StringBuilder(s.Length);
        var st = new Stack<(int start, int repeat)>();

        foreach(var c in s)    
        {
            if(c == '[')
            {
                st.Push((sb.Length, repeat));
                repeat = 0;
            }
            else if(c == ']')
            {
                var (start, times) = st.Pop();

                for(var length = sb.Length - start; times > 1; times--)
                {
                    sb.Append(sb, start, length);
                }
            }
            else if(Char.IsDigit(c))
            {
                repeat = 10 * repeat + (c - '0');
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}