public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        Func<int[], Dictionary<int,int>> GetFreqs =
		a => a.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

	var freqs1 = GetFreqs(nums1);
	var freqs2 = GetFreqs(nums2);

	var list = new List<int>();

	foreach (var kvp in freqs1)
		if (freqs2.ContainsKey(kvp.Key))
			for (var i = 0; i < Math.Min(kvp.Value, freqs2[kvp.Key]); i++)
				list.Add(kvp.Key);

	return list.ToArray();
    }
}