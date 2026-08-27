public class Solution {
    public int[] SecondGreaterElement(int[] nums) {
        int n = nums.Length;
        int[] res = Enumerable.Repeat(-1, n).ToArray();
        var first = new Stack<int>();
        var second = new Stack<int>();

        for (int i = 0; i < n; i++) {
            // Resolve second greater
            var temp = new Stack<int>();
            while (second.Count > 0 && nums[i] > nums[second.Peek()]) {
                res[second.Pop()] = nums[i];
            }

            // Promote first greater to second stack
            while (first.Count > 0 && nums[i] > nums[first.Peek()]) {
                temp.Push(first.Pop());
            }
            while (temp.Count > 0) {
                second.Push(temp.Pop());
            }

            // Push current index to first stack
            first.Push(i);
        }

        return res;
    }
}