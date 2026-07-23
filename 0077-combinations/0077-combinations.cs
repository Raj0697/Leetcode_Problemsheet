public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> currentCombination = new List<int>();
        Backtrack(1, n, k, currentCombination, result);
        return result;
    }
    private void Backtrack(int start, int n, int k, List<int> currentCombination, IList<IList<int>> result) {
        if (currentCombination.Count == k) {
            result.Add(new List<int>(currentCombination));
            return;
        }
        
        for (int i = start; i <= n; i++) {
            currentCombination.Add(i);
            Backtrack(i + 1, n, k, currentCombination, result);
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}