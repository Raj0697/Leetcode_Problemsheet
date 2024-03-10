public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        var set = new HashSet<int>(nums1);
	var res = new HashSet<int>();
	foreach (var num in nums2)
		if (set.Remove(num))
			res.Add(num);
	return res.ToArray();
    }
}