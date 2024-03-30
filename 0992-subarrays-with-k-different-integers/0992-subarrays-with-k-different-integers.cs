public class Solution {
    public int SubarraysWithKDistinct(int[] A, int K) {
        int res = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int start = 0;
        int current = 0;
        for(int i = 0; i < A.Length; i++) {
            if(dict.ContainsKey(A[i])) {
                dict[A[i]]++;
            } else {
                dict[A[i]] = 1;
            }
            if(dict.Keys.Count >= K) {
                while(dict[A[current]] > 1) {
                    dict[A[current++]]--;    
                }
                if (dict.Keys.Count == K) {
                    res += current - start + 1;
                } else {
                    dict.Remove(A[current++]);
                    start = current;
                    dict[A[i]] = 0;
                    i--;
                }
            } 
        }
        return res;
    }
}