public class Solution {
    public IList<int> LexicalOrder(int n) {
        List<int> result = new List<int>();
        int current = 1;

        for (int i = 0; i < n; i++) {
            result.Add(current);
            
            // Try to go deeper (multiply by 10)
            if (current * 10 <= n) {
                current *= 10;
            } 
            // Increment current, or handle boundary and end digits
            else if (current % 10 != 9 && current + 1 <= n) {
                current++;
            } 
            // Backtrack until we can increment to next valid number
            else {
                while ((current / 10) % 10 == 9) {
                    current /= 10;
                }
                current = current / 10 + 1;
            }
        }

        return result;
    }
}