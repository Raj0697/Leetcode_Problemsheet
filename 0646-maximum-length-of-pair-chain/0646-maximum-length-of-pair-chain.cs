public class Solution {
    public int FindLongestChain(int[][] pairs) {
         Array.Sort(pairs, (a, b) => a[1].CompareTo(b[1]));

 int cur = int.MinValue, ans = 0;

 foreach (var pair in pairs)
 {
     if (cur < pair[0])
     {
         cur = pair[1];
         ans++;
     }
 }

 return ans;
    }
}