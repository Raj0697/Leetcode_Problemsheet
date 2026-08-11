public class Solution {
    private const int MOD = 1_000_000_007;

    public int CreateSortedArray(int[] instructions) {
        int n = instructions.Length;

        // Step 1: Coordinate compression
        var unique = new HashSet<int>(instructions);
        var sortedUnique = unique.ToArray();
        Array.Sort(sortedUnique);
        var rankMap = new Dictionary<int, int>();
        for (int i = 0; i < sortedUnique.Length; i++) {
            rankMap[sortedUnique[i]] = i + 1; // ranks from 1 to m
        }

        int maxRank = sortedUnique.Length;

        // Step 2: Fenwick Tree for frequencies
        int[] fenwick = new int[maxRank + 2];

        long totalCost = 0;
        int inserted = 0;

        foreach (int val in instructions) {
            int r = rankMap[val];

            // Query number of elements < val (strictly less)
            long left = Query(fenwick, r - 1);

            // Number of elements > val = total - (less + equal)
            long equal = Query(fenwick, r) - left;
            long right = inserted - left - equal;

            // Cost = min(left, right)
            totalCost = (totalCost + Math.Min(left, right)) % MOD;

            // Insert this value
            Update(fenwick, r, 1);
            inserted++;
        }

        return (int)totalCost;
    }

    // Fenwick Tree: sum from 1 to idx
    private long Query(int[] fenwick, int idx) {
        long sum = 0;
        while (idx > 0) {
            sum += fenwick[idx];
            idx -= idx & -idx;
        }
        return sum;
    }

    // Fenwick Tree: add val at position idx
    private void Update(int[] fenwick, int idx, int val) {
        while (idx < fenwick.Length) {
            fenwick[idx] += val;
            idx += idx & -idx;
        }
    }
}