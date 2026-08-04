public class Solution {
    public int[] MovesToStamp(string stamp, string target) {
        int n = target.Length;
        int m = stamp.Length;
        char[] s = target.ToCharArray();
        List<int> ans = new List<int>();
        int stars = n;
        
        // Repeat until all positions are stamped (turned to '?')
        while (stars > 0) {
            bool stamped = false;
            
            // Try to find a position to stamp
            for (int i = 0; i <= n - m; i++) {
                bool canStamp = true;
                int nonStarCount = 0;
                
                // Check if we can stamp at position i
                for (int j = 0; j < m; j++) {
                    if (s[i + j] != '?' && s[i + j] != stamp[j]) {
                        canStamp = false;
                        break;
                    }
                    if (s[i + j] != '?') nonStarCount++;
                }
                
                // Only stamp if it covers at least one non-'?' character
                if (canStamp && nonStarCount > 0) {
                    // Apply stamp (turn to '?')
                    for (int j = 0; j < m; j++) {
                        s[i + j] = '?';
                    }
                    ans.Add(i);
                    stars -= nonStarCount;
                    stamped = true;
                    break;
                }
            }
            
            // If we couldn't stamp anything but still have non-'?' → impossible
            if (!stamped) {
                return new int[0];
            }
        }
        
        // Reverse the order (last stamped was first undone)
        ans.Reverse();
        return ans.ToArray();
    }
}