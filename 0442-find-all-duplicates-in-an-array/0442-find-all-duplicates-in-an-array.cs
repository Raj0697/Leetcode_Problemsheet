public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        var set = new HashSet<int>();
        return nums.Where(num => !set.Add(num)).ToList();
    }
}