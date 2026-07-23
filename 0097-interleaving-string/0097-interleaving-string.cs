public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        if (s1.Length + s2.Length != s3.Length)
            return false;

        var memo = new Dictionary<(int, int), bool>();
        return DFS(0, 0);

        bool DFS(int i, int j) {
            if (i == s1.Length && j == s2.Length)
                return true;

            if (memo.ContainsKey((i, j)))
                return memo[(i, j)];

            int k = i + j;

            if (i < s1.Length && s1[i] == s3[k] && DFS(i + 1, j)) {
                memo[(i, j)] = true;
                return true;
            }

            if (j < s2.Length && s2[j] == s3[k] && DFS(i, j + 1)) {
                memo[(i, j)] = true;
                return true;
            }

            memo[(i, j)] = false;
            return false;
        }
    }
}