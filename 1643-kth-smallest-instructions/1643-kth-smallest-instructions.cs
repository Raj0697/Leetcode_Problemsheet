public class Solution {
    public string KthSmallestPath(int[] dest, int k) {
        int row = dest[0], col = dest[1];
        int total = row + col;
        char[] path = new char[total];
        int pos = 0;

        while (row > 0 || col > 0) {
            if (col > 0) {
                int count = (int)Comb(row + col - 1, col - 1);
                if (k <= count) {
                    path[pos++] = 'H';
                    col--;
                } else {
                    path[pos++] = 'V';
                    row--;
                    k -= count;
                }
            } else {
                path[pos++] = 'V';
                row--;
            }
        }

        return new string(path);
    }

    private long Comb(int n, int k) {
        long res = 1;
        for (int i = 1; i <= k; i++) {
            res = res * (n - i + 1) / i;
        }
        return res;
    }
}