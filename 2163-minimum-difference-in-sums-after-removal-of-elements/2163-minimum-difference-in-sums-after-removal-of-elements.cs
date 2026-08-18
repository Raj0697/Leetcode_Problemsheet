public class Solution
{
    public long MinimumDifference(int[] nums)
    {
        int n = nums.Length;
        int k = n / 3;
        long sum = 0;

        // Initialize two priority queues: one for max-heap (using negative values) and one for min-heap
        PriorityQueue<long, long> maxQ = new PriorityQueue<long, long>(Comparer<long>.Create((a, b) => b.CompareTo(a))); // Max-heap
        PriorityQueue<long, long> minQ = new PriorityQueue<long, long>(); // Min-heap

        // Arrays to store the prefix and suffix sums
        long[] pre = new long[n];
        long[] suff = new long[n];

        // Compute the prefix sums using max-heap
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            maxQ.Enqueue(nums[i], nums[i]);

            // If the max-heap has more than 'k' elements, pop the largest (to keep the smallest k elements)
            if (maxQ.Count > k)
            {
                sum -= maxQ.Dequeue(); // Remove the largest element
            }

            // When there are at least 'k' elements in the heap, record the sum of the smallest 'k' elements
            if (maxQ.Count >= k)
            {
                pre[i] = sum;
            }
        }

        // Reset sum for suffix calculations
        sum = 0;

        // Compute the suffix sums using min-heap
        for (int i = n - 1; i >= 0; i--)
        {
            sum += nums[i];
            minQ.Enqueue(nums[i], nums[i]);

            // If the min-heap has more than 'k' elements, pop the smallest (to keep the largest k elements)
            if (minQ.Count > k)
            {
                sum -= minQ.Dequeue(); // Remove the smallest element
            }

            // When there are at least 'k' elements in the heap, record the sum of the largest 'k' elements
            if (minQ.Count >= k)
            {
                suff[i] = sum;
            }
        }

        // Initialize the result to the largest possible value
        long ans = long.MaxValue;

        // Compare the pre-sums and suff-sums to find the minimum difference
        for (int i = k - 1; i < n - k; i++)
        {
            ans = Math.Min(ans, pre[i] - suff[i + 1]);
        }

        return ans;
    }
}