public class Solution {
    public int ValidSubarraySize(int[] nums, int threshold) {
        int n = nums.Length;
        int[] left = new int[n], right = new int[n];
        Array.Fill(left, -1);
        Array.Fill(right, n);

        Stack<int> stack = new();

        // Prefix: nearest smaller to the left
        for (int i = 0; i < n; i++) {
            while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                stack.Pop();
            if (stack.Count > 0) left[i] = stack.Peek();
            stack.Push(i);
        }

        stack.Clear();

        // Suffix: nearest smaller to the right
        for (int i = n - 1; i >= 0; i--) {
            while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                stack.Pop();
            if (stack.Count > 0) right[i] = stack.Peek();
            stack.Push(i);
        }

        // Check each interval
        for (int i = 0; i < n; i++) {
            int len = right[i] - left[i] - 1;
            if (nums[i] > threshold / len)
                return len;
        }

        return -1;
    }
}