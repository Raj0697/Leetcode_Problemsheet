public class Solution {
    public int HeightChecker(int[] heights) {
        return heights.OrderBy(x => x)
            .Select((s, i) => heights[i] == s ? 0 : 1)
            .Sum();
    }
}