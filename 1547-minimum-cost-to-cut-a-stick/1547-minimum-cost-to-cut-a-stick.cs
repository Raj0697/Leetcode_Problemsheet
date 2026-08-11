public class Solution
{
    public int MinCost(int n, int[] cuts)
    {
        // Sort the cuts array
        Array.Sort(cuts);
        
        // Create a new array to hold the cuts including the endpoints of the stick
        int[] allCuts = new int[cuts.Length + 2];
        allCuts[0] = 0; // Start of the stick
        Array.Copy(cuts, 0, allCuts, 1, cuts.Length);
        allCuts[cuts.Length + 1] = n; // End of the stick
        
        // Initialize the DP table
        int len = allCuts.Length;
        int[,] dp = new int[len, len];
        
        // Fill the DP table
        for (int length = 2; length < len; length++)
        {
            for (int i = 0; i < len - length; i++)
            {
                int j = i + length;
                dp[i, j] = int.MaxValue;
                
                // Calculate the cost for all possible cuts between i and j
                for (int k = i + 1; k < j; k++)
                {
                    // Cost of cutting at position k plus the cost of the segments
                    int cost = allCuts[j] - allCuts[i] + dp[i, k] + dp[k, j];
                    dp[i, j] = Math.Min(dp[i, j], cost);
                }
            }
        }
        
        // The result is the minimum cost to cut the entire stick
        return dp[0, len - 1];
    }
}