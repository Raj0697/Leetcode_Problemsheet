public class Solution
{
    private const int Mod = 1_000_000_007;

    private int Dfs(int n, List<List<int>> adj, int src, int[,] dp)
    {
        if (n == 0) return 1;
        if (dp[n, src] != -1) return dp[n, src];

        int totalWays = 0;
        foreach (var neighbor in adj[src])
        {
            totalWays = (totalWays + Dfs(n - 1, adj, neighbor, dp)) % Mod;
        }

        return dp[n, src] = totalWays;
    }

    private void GenerateValidColors(List<string> colors, int lastColor, int remaining, string current)
    {
        if (remaining == 0)
        {
            colors.Add(current);
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            if (lastColor != i)
            {
                GenerateValidColors(colors, i, remaining - 1, current + i);
            }
        }
    }

    private bool AreColorsCompatible(string color1, string color2)
    {
        for (int i = 0; i < color1.Length; i++)
        {
            if (color1[i] == color2[i]) return false;
        }
        return true;
    }

    public int ColorTheGrid(int m, int n)
    {
        var colorCombinations = new List<string>();
        for (int i = 0; i < 3; i++)
        {
            GenerateValidColors(colorCombinations, i, m - 1, i.ToString());
        }

        var adj = new List<List<int>>(colorCombinations.Count);
        for (int i = 0; i < colorCombinations.Count; i++)
        {
            adj.Add(new List<int>());
        }

        for (int i = 0; i < adj.Count; i++)
        {
            for (int j = 0; j < adj.Count; j++)
            {
                if (AreColorsCompatible(colorCombinations[i], colorCombinations[j]))
                {
                    adj[i].Add(j);
                }
            }
        }

        var dp = new int[n + 1, adj.Count];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j < adj.Count; j++)
            {
                dp[i, j] = -1;
            }
        }

        int totalWays = 0;
        for (int i = 0; i < colorCombinations.Count; i++)
        {
            totalWays = (totalWays + Dfs(n - 1, adj, i, dp)) % Mod;
        }

        return totalWays;
    }
}