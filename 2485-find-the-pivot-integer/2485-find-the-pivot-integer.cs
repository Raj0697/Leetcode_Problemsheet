public class Solution {
    public int PivotInteger(int n) {
        double x=Math.Sqrt((n*n+n)/2);
        int y=(int)x;
        if(y==x)
            return y;
        return -1;
    }
}