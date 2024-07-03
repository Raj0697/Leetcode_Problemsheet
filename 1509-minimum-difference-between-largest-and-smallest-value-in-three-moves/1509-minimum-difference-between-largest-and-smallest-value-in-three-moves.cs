public class Solution {
    public int MinDifference(int[] A) {
        Array.Sort(A);
        return A.Length <= 4 ? 0 : new int[] { A[^1] - A[3], A[^2] - A[2], A[^3] - A[1], A[^4] - A[0] }.Min();
    }
}