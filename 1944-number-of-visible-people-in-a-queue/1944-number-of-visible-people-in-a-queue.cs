public class Solution {
    public int[] CanSeePersonsCount(int[] heights) {
        int n = heights.Length;
        int[] result = new int[n];
        Stack<int> stack = new Stack<int>();

        // Traverse from right to left
        for (int i = n - 1; i >= 0; i--) {
            // Pop elements from the stack that are shorter than the current person
            while (stack.Count > 0 && heights[stack.Peek()] < heights[i]) {
                result[i]++;
                stack.Pop();
            }
            // The person currently on the top of the stack can be seen by the current person
            if (stack.Count > 0) {
                result[i]++;
            }
            // Push current person onto the stack
            stack.Push(i);
        }

        return result;
    }
}