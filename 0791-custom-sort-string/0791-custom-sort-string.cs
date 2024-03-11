public class Solution {
    public string CustomSortString(string order, string s) {
        int[] sortOrder = new int[26];

        for (int i = 0; i < order.Length; i++)
        {
            sortOrder[order[i] - 'a'] = i + 1;
        }

        char[] str = s.ToCharArray();

        Array.Sort(str, (a, b) => 
        {
            return sortOrder[a - 'a'] - sortOrder[b - 'a'];
        });

        return new string(str);
    }
}