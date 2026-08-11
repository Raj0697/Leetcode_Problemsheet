public class Solution
{
    public int LongestAwesome(string s)
    {
        // Initialize the length of the longest awesome substring
        int maxLength = 0;
        
        // A dictionary to store the first occurrence of each bitmask
        Dictionary<int, int> seen = new Dictionary<int, int>();
        
        // Initial condition: an empty substring has a bitmask of 0
        seen[0] = -1;
        
        // Variable to maintain the current bitmask
        int bitmask = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            // Toggle the bit corresponding to the current digit
            bitmask ^= (1 << (s[i] - '0'));
            
            // Check if the current bitmask has been seen before
            if (seen.ContainsKey(bitmask))
            {
                // Update the maxLength if we found a longer awesome substring
                maxLength = Math.Max(maxLength, i - seen[bitmask]);
            }
            else
            {
                // Record the first occurrence of the current bitmask
                seen[bitmask] = i;
            }
            
            // Check for palindromic potential by toggling each bit (for odd counts)
            for (int j = 0; j < 10; j++)
            {
                int toggleMask = bitmask ^ (1 << j);
                if (seen.ContainsKey(toggleMask))
                {
                    maxLength = Math.Max(maxLength, i - seen[toggleMask]);
                }
            }
        }
        
        return maxLength;
    }
}