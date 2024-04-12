public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int maxi = 0;
        for (int i = 1; i < n; i++) {
            if (height[maxi] < height[i]) {
                maxi = i;
            }
        }

        int res = 0;

        int max = height[0];
        for (int i = 0; i <= maxi; i++) {
            res += Math.Max(0, max - height[i]);
            if (height[i] > max) {
                max = height[i];
            }
        }

        max = height[n-1];
        for (int i = n-1; i >= maxi; i--) {
            res += Math.Max(0, max - height[i]);
            if (height[i] > max) {
                max = height[i];
            }
        }

        return res;
    }
}