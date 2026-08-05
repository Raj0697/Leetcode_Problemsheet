public class Solution
{
    public string CountAndSay(int n)
    {
        if (n == 1) return "1";

        string result = "1";
        for (int i = 1; i < n; i++)
        {
            result = GetNextSequence(result);
        }
        return result;
    }

    private string GetNextSequence(string s)
    {
        var sb = new System.Text.StringBuilder();
        int count = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                sb.Append(count).Append(s[i - 1]);
                count = 1;
            }
        }

        // Append the last counted character
        sb.Append(count).Append(s[s.Length - 1]);

        return sb.ToString();
    }
}
