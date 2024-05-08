public class Solution {
    public string[] FindRelativeRanks(int[] nums) {
        string[] firstThree = { "Gold Medal", "Silver Medal", "Bronze Medal" };

	var ranks = nums.Select((x, i) => (score: x, index: i))
		.OrderByDescending(x => x.score)
		.Select((x, i) => i < 3 ? (index: x.index, rank: firstThree[i]) 
				: (index: x.index, rank: (i + 1).ToString()))
		.OrderBy(x => x.index)
		.Select(x => x.rank)
		.ToArray();

	return ranks;
    }
}