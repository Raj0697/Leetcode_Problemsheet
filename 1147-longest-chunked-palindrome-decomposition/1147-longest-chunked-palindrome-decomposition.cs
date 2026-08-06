public class Solution {
    public int LongestDecomposition(string text)
    {
        string helper = text;
        int count = 0;

        void Recursive(string txt)
        {
            helper = txt;
            for (int i = 1; i <= txt.Length / 2; i++)
            {
                if (txt.Substring(0, i) == txt.Substring(txt.Length - i))
                {
                    count += 2;
                    Recursive(txt.Substring(i, txt.Length - 2 * i));
                    break;
                }
            }
        }

        Recursive(text);
        return (helper == "") ? count : count + 1;
    }
}