class Solution {
    public int climbStairs(int n) {
        if(n <= 0)
            return 0;
        if(n == 1)
            return 1;
        if(n == 2)
            return 2;
        int total = 0, nminus1 = 2, nminus2 = 1;
        for(int i=2; i<n; i++) {
            total = nminus1 + nminus2;
            nminus2 = nminus1;
            nminus1 = total;
        }
        return total;
    }
}