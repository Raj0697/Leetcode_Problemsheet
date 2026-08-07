public class Solution {
    public int LongestSubsequence(int[] arr, int difference) {
          Dictionary<int, int> preCnt = new();
  int len = arr.Length, res = 1, maxSame = 1;
  for (int i = 0; i < len; i++)
  {
      int cur = arr[i];
      int pre = cur - difference;
      int cnt = 1;
      if (preCnt.ContainsKey(pre))
          cnt += preCnt[pre];

      if (preCnt.ContainsKey(cur))
          preCnt[cur] = Math.Max(preCnt[cur], cnt);
      else
          preCnt.Add(cur, cnt);

      res = Math.Max(res, preCnt[cur]);
  }

  return res;
    }
}