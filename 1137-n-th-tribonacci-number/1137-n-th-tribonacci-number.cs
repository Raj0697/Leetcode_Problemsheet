public class Solution {
    public int Tribonacci(int n) {
        int[] trib = new int[38];
        trib[0] = 0;
        trib[1] =  trib[2] = 1;
        for(int i = 3; i <= n; i++) {
            trib [i] =   trib [i - 1] + trib [i - 2] + trib [i - 3] ; 
        }
        return trib[n];   
    }
}