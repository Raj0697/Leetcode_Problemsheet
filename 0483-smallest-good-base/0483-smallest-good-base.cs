public class Solution {
    public string SmallestGoodBase(string n) {
        long num = long.Parse(n);
        for (int m = (int)(Math.Log(num + 1) / Math.Log(2)); m >= 2; m--) {
            long left = 2, right = (long)Math.Pow(num, 1.0 / (m - 1)) + 1;
            while (left < right) {
                long mid = left + (right - left) / 2;
                long sum = 0;
                for (int j = 0; j < m; j++) {
                    sum = sum * mid + 1;
                }
                if (sum == num) {
                    return mid.ToString();
                } else if (sum < num) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
        }
        return (num - 1).ToString();
    }
}