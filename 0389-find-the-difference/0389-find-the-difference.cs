public class Solution 
{
    public char FindTheDifference(string s, string t) 
    {
        Dictionary<char, int> count = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!count.ContainsKey(c))
                count[c] = 0;

            count[c]++;
        }

        foreach (char c in t)
        {
            if (!count.ContainsKey(c) || count[c] == 0)
            {
                return c; 
            }

            count[c]--;
        }

        return '\0';
    }
}