public class Solution {
    public int NumDupDigitsAtMostN(int n) {
        string s = n.ToString();
        int len = s.Length;
        int count = 0;
        for (int i = 1; i < len; i++) {
            count += 9 * Permutation(9, i - 1);}
        bool[] used = new bool[10];
        for (int i = 0; i < len; i++) {
            int digit = s[i] - '0';
            for (int j = (i == 0 ? 1 : 0); j < digit; j++) {
                if (!used[j]) {
                    count += Permutation(10 - 1 - i, len - 1 - i);}}
            if (used[digit]) break;
            used[digit] = true;
            if (i == len - 1) count++;}
        return n - count;}
    private int Permutation(int m, int k) {
        int res = 1;
        for (int i = 0; i < k; i++) {
            res *= (m - i);}
        return res;}}