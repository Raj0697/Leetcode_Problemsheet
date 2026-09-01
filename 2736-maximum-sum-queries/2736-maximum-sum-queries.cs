public class Solution
{
    public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries)
    {
        // Combine nums1 and nums2 into pairs, then sort them by nums1 ascending.
        var nums = nums1.Zip(nums2, (v, u) => (v, u)).OrderBy(t => t.v).ToList();
        
        // Stack to maintain valid pairs for query processing.
        var stack = new LinkedList<(int ny, int sum)>();
        
        // Initialize the result array with -1 for no valid result.
        var result = new int[queries.Length];
        Array.Fill(result, -1);

        // Prepare queries with indices and sort them in descending order of x.
        var indexedQueries = queries
            .Select((q, i) => (x: q[0], y: q[1], index: i))
            .OrderByDescending(t => t.x)
            .ToList();

        // Process queries in reverse order.
        for (int k = 0, nIndex = nums.Count - 1; k < indexedQueries.Count; k++)
        {
            var (x, y, queryIndex) = indexedQueries[k];

            // Add elements from nums that satisfy the current query's x constraint.
            while (nIndex >= 0 && nums[nIndex].v >= x)
            {
                var (nx, ny) = nums[nIndex];
                nIndex--;

                // Maintain the stack to ensure it always contains the maximum sums for valid pairs.
                while (stack.Count > 0 && stack.Last.Value.ny <= ny && stack.Last.Value.sum < nx + ny)
                {
                    stack.RemoveLast();
                }

                // Add the current element if it is not dominated.
                if (stack.Count == 0 || stack.Last.Value.ny < ny)
                {
                    stack.AddLast((ny, nx + ny));
                }
            }

            // Find the first valid sum in the stack for the current query's y constraint.
            foreach (var (ny, sum) in stack)
            {
                if (ny >= y)
                {
                    result[queryIndex] = sum;
                    break;
                }
            }
        }

        return result;
    }
}
