public class Solution {
    public int FindCenter(int[][] edges) {
        var node = edges[0]
            .Intersect(edges[1])
            .First();
        return node;
    }
}