public class Solution {
     public bool CanTraverseAllPairs(int[] nums)
    {
        var n = nums.Length;
        var graph = BuildGraph(nums);
        var visited = new bool[n];
        Dfs(0, visited, graph);

        return visited.All(v => v);
    }

    private static List<int>[] BuildGraph(int[] nums)
    {
        var n = nums.Length;
        var graph = InitializeGraph(n);
        var map = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            AddPrimeFactorsToGraph(num, i, map, graph);
        }

        return graph;
    }

    private static List<int>[] InitializeGraph(int n)
    {
        var graph = new List<int>[n];

        for (var i = 0; i < n; i++)
            graph[i] = new List<int>();

        return graph;
    }

    private static void AddPrimeFactorsToGraph(int num, int index, Dictionary<int, int> map, List<int>[] graph)
    {
        for (var j = 2; j * j <= num; j++)
            if (num % j == 0)
            {
                AddFactorToGraph(j, index, map, graph);

                while (num % j == 0)
                    num /= j;
            }

        if (num > 1)
            AddFactorToGraph(num, index, map, graph);
    }

    private static void AddFactorToGraph(int factor, int index, Dictionary<int, int> map, List<int>[] graph)
    {
        if (!map.ContainsKey(factor))
            map[factor] = index;
        else
        {
            var node = map[factor];
            graph[index].Add(node);
            graph[node].Add(index);
        }
    }

    private static void Dfs(int node, bool[] visited, List<int>[] graph)
    {
        visited[node] = true;

        foreach (var neighbor in graph[node].Where(neighbor => !visited[neighbor]))
            Dfs(neighbor, visited, graph);
    }
}