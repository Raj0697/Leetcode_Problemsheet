public class Solution {
    public int FindMaxK(int[] nums) => nums
        .Where(int.IsNegative)
        .Select(int.Abs)
        .Intersect(nums.Where(int.IsPositive))
        .DefaultIfEmpty(-1)
        .Max();
}