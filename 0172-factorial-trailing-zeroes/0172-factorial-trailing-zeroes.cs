public class Solution {
    public int TrailingZeroes(int n, int result = 0) => n > 0
        ? TrailingZeroes(n / 5, result + (n / 5))
        : result;
}