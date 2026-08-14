public class Solution {
    public int[] RecoverArray(int n, int[] sums) {
        Array.Sort(sums);
        int m = sums.Length;
        int zeroShift = 0;
        int[] res = new int[n];

        for (int i = 0; i < n; ++i) {
            int diff = sums[1] - sums[0];
            int zpos = m;

            int[] temp = new int[m];
            Array.Copy(sums, temp, m);
            Array.Sort(temp);

            Dictionary<int, int> count = new Dictionary<int, int>();
            foreach (int x in temp) {
                if (!count.ContainsKey(x)) count[x] = 0;
                count[x]++;
            }

            int p = 0;
            foreach (int x in temp) {
                if (count[x] == 0) continue;
                count[x]--;
                int y = x + diff;
                count[y]--;
                if (x == zeroShift) zpos = p;
                sums[p++] = y;
            }

            if (zpos >= m / 2) {
                res[i] = -diff;
            } else {
                res[i] = diff;
                zeroShift += diff;
            }

            m /= 2;
        }

        return res;
    }
}