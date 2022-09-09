public class Solution {
    // you need to treat n as an unsigned value
    public int hammingWeight(int n) {
        //return Integer.bitCount(n);
        // the above line works correctly
        int res = 0;
        while(n != 0) {
            n = (n & (n-1));
            res++;
        }
        return res;
    }
}