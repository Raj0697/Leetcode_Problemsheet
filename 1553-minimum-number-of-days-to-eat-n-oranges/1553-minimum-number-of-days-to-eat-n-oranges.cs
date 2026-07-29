public class Solution {
    private Dictionary<int, int> dict = new();
    private int GetMin(int n)
    {
        if(n == 0)
            return 0;

        if(dict.ContainsKey(n))
            return dict[n];

        int res = n;
        res = 1 + Math.Min(n%2 + GetMin(n/2), (n%3)+GetMin(n/3));
        dict.Add(n, res);
        return res;
    }
    public int MinDays(int n) {
        return GetMin(n)-1;
    }
}