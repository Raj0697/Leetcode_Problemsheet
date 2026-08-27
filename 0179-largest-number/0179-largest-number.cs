public class Solution {
    public string LargestNumber(int[] nums) {
        if (nums.All(n => n == 0)) return "0";
        var strNums = nums.Select(n => n.ToString()).ToArray();
        Array.Sort(strNums, (a, b) => (b + a).CompareTo(a + b));
        return string.Concat(strNums);
    }
}