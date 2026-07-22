public class Solution {
    public IList<int> PartitionLabels(string S) {
        
        // last index of each character
        int[] last = new int[26];
        for(int i = 0; i < S.Length; i++)
            last[S[i] - 'a'] = i;
        
        List<int> res = new List<int>();
        int begin = 0, end = 0;
        for(int j = 0; j < S.Length; j++)
        {
            end = Math.Max(end, last[S[j] - 'a']);
            if(j == end)
            {
                res.Add(end - begin + 1);
                begin = end + 1;
            }
        }
        
        return res;
    }
}