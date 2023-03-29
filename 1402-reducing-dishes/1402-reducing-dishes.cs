public class Solution {
    public int MaxSatisfaction(int[] satisfaction) {
        Array.Sort(satisfaction, (a, b) => b.CompareTo(a));

        int result = 0;

        for (int i = 0, prefix = 0, current = 0; i < satisfaction.Length; ++i) 
            result = Math.Max(result, current += prefix += satisfaction[i]);
 
        return result;
    }
}