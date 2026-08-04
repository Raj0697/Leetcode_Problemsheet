public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        int n = arr.Length;
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);

        long sumOrig = 0, sumSorted = 0;
        int chunks = 0;

        for (int i = 0; i < n; i++) {
            sumOrig += arr[i];
            sumSorted += sorted[i];

            if (sumOrig == sumSorted) {
                chunks++;
            }
        }

        return chunks;
    }
}