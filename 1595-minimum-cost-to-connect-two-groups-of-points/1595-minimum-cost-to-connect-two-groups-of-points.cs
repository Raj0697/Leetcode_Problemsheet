public class Solution {
    private int[] minCost;
    private int size1, size2;
    private int[,] dp;
    private int BackTracking(int idx, int mask, IList<IList<int>> cost)
    {
        if(idx == size1)
        {
            int totalCost = 0;
            for(int j = 0; j < size2; j++)
            {
                if(((mask>>j)&1) == 0)
                    totalCost += minCost[j];
            }

            return totalCost;
        }

        if(dp[idx, mask] != -1)
            return dp[idx, mask];

        int res = int.MaxValue;
        for(int j = 0; j < size2; j++)
        {
            res = Math.Min(res, BackTracking(idx+1, (mask | (1<<j)), cost) + cost[idx][j]);
        }

        dp[idx, mask] = res;
        return res;
    }
    public int ConnectTwoGroups(IList<IList<int>> cost) {
        size1 = cost.Count;
        size2 = cost[0].Count;
        minCost = Enumerable.Repeat(int.MaxValue, size2).ToArray();

        for(int i = 0; i < size1; i++)
        {
            for(int j = 0; j < size2; j++)
            {
                minCost[j] = Math.Min(minCost[j], cost[i][j]);
            }
        }

        int fullMask = (1<<size2);
        dp = new int[size1, fullMask];
        for(int i = 0; i < size1; i++)
        {
            for(int j = 0; j < fullMask; j++)
            {
                dp[i,j] = -1;
            }
        }

        return BackTracking(0, 0, cost);
    }
}