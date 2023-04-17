public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        // int n = candies.Length;
        // bool[] result = new bool[n];
        // int max = candies.Max();
        // for(int i = 0; i < n; i++)
        // {
        //     result[i] = candies[i] + extraCandies >= max ? true : false;
        // }
        // return result;
        var max = candies.Max();
        return candies.Select(c => c + extraCandies >= max).ToList();
    }
}