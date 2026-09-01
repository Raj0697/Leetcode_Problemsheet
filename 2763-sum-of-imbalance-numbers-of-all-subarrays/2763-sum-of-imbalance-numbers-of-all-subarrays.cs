public class Solution {
    public int SumImbalanceNumbers(int[] nums) {
        int N = nums.Length;

        // Initialize an array to store the last seen index for each number
        int[] lastIndex = new int[N + 2];
        Array.Fill(lastIndex, N);

        // Array to store the right edge for each element
        int[] rightEdge = new int[N];
        for (int i = N - 1; i >= 0; --i) {
            int num = nums[i];
            rightEdge[i] = Math.Min(lastIndex[num], lastIndex[num + 1]);
            lastIndex[num] = i;
        }

        int count = 0;

        // Reset lastIndex to track left edge positions
        Array.Fill(lastIndex, -1);
        for (int i = 0; i < N; ++i) {
            int num = nums[i];
            int leftEdge = lastIndex[num + 1];
            count += (i - leftEdge) * (rightEdge[i] - i);
            lastIndex[num] = i;
        }

        // Subtract the total number of subarrays from the result
        return count - N * (N + 1) / 2;
    }
}