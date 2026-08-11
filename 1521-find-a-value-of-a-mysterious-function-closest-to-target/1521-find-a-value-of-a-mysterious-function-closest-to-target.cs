public class Solution {
    public int ClosestToTarget(int[] arr, int target) {
        int n = arr.Length;
        int minDiff = int.MaxValue;
        HashSet<int> visited = new HashSet<int>();

        foreach (int cur in arr) {
            // Update with current single element
            minDiff = Math.Min(minDiff, Math.Abs(target - cur));

            if (minDiff == 0) return 0;
            List<int> tmp = new List<int> { cur };

            // Combine with all previous AND values
            foreach (int prev in visited) {
                int andV = prev & cur;
                minDiff = Math.Min(minDiff, Math.Abs(target - andV));

                if (minDiff == 0) return 0;

                tmp.Add(andV);
            }

            // Update visited with new AND values
            visited = new HashSet<int>(tmp);
        }

        return minDiff;
    }
}