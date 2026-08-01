public class Solution {
    public int PreimageSizeFZF(int k) {
        ++k;
        var ml = 31L; // motif length

        for (; ml <= k; ml = 5 * ml + 1);

        ml = (ml - 1) / 5;

        while (k % ml > 0) {
            k %= (int)ml;
            ml = (ml - 1) / 5;
        }

        return ml == 1 ? 5 : 0;
    }
}