public class Solution {
    const long MODULO = 1000000007;
    public int NumTilings(int n) {
        var dpr = new long[n+1];
        var dpu = new long[n+1];
        var dpd = new long[n+1];
        dpr[0] = 1;
        dpr[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            dpu[i] = (dpd[i-1] + dpr[i-2]) % MODULO;
            dpd[i] = (dpu[i-1] + dpr[i-2]) % MODULO;
            dpr[i] = (dpr[i-1] + dpr[i-2] + dpu[i-1] + dpd[i-1]) % MODULO;
        }

        return (int)dpr[n];
    }
}