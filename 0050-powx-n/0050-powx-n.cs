public class Solution {
    public double MyPow(double x, int n) {
        long N = n;
        if (N == 0) return 1;
        if (N < 0) {
            x = 1 / x;
            N = -N;
        }
        return CalculatePow(x, N);
    }
    private double CalculatePow(double x, long n) {
        if (n == 1) return x;
        double halfPow = CalculatePow(x, n / 2);
        return n % 2 == 0 ? halfPow * halfPow : halfPow * halfPow * x;
    }
}