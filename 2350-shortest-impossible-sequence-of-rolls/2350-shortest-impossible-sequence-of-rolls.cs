class Solution {
    public int ShortestSequence(int[] rolls, int k) {
        // Use a HashSet to track unique dice values in the current subsequence
        var currentSet = new System.Collections.Generic.HashSet<int>();
        int result = 0;

        // Iterate through the rolls array
        foreach (var roll in rolls) {
            // Add the current roll to the set
            currentSet.Add(roll);

            // If the set contains all dice values (1 to k), increment the result
            if (currentSet.Count == k) {
                result++;
                currentSet.Clear(); // Reset the set for the next subsequence
            }
        }

        // The result represents the shortest impossible sequence length
        return result + 1;
    }
}