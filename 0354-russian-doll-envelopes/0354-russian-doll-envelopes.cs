public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
            int[][] arr = envelopes.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
            int sum = 0;
            List<int> ls = new List<int>();
            for(int i = 0; i < arr.Length; i++) {
                int bx = arr[i][1];
                if(ls.Count == 0) {
                    ls.Add(bx);
                }
                else if(ls[ls.Count-1] < bx) {
                    ls.Add(bx);
                }
                else {
                    int start = 0;
                    int end = ls.Count - 1;
                    int ind = -1;
                    while(start <= end) {
                        int mid = (start + end) / 2;
                        if(ls[mid] >= bx) {
                            ind = mid;
                            end = mid - 1;
                        }
                        else {
                            start = mid + 1;
                        }
                    }
                    ls[ind] = bx;
                }
            }
            return ls.Count;
    }
}