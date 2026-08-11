public class Solution {
    public int[] CountSubgraphsForEachDiameter(int n, int[][] edges) 
    {
        var result = new int[n - 1];
        for(int mask = 1; mask <= (1 << n); ++mask)
        {
            var vertexes = new HashSet<int>();
            var matrix = new long[n, n];
            var edgesCount = 0;

            for(int i = 0; i < n; ++i)
            {
                if((mask & (1 << i)) > 0)
                {
                    vertexes.Add(i);
                }
            }
            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    if(i != j)
                    {
                        matrix[i, j] = int.MaxValue;
                    }
                }
            }

            foreach(var edge in edges)
            {
                var start = edge[0] - 1;
                var end = edge[1] - 1;
                if( vertexes.Contains(start) && 
                    vertexes.Contains(end) )
                    {
                        ++edgesCount;
                        matrix[start, end] = 1;
                        matrix[end, start] = 1;
                    }
            }

            if(vertexes.Count - 1 == edgesCount && edgesCount > 0)
            {
                for(int k = 0; k < n; ++k)
                {
                    for(int i = 0; i < n; ++i)
                    {
                        for(int j = 0; j < n; ++j)
                        {
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + 
                                                                matrix[k, j]);
                        }
                    }
                }

                var maxDistance = 0;
                for(int i = 0; i < n; ++i)
                {
                    for(int j = 0; j < n; ++j)
                    {
                        if(matrix[i, j] != int.MaxValue)
                        {
                            maxDistance = (int)Math.Max(maxDistance, matrix[i, j]);
                        }
                    }
                }
                 
                if(maxDistance > 0 && maxDistance <= n - 1)
                {
                    result[maxDistance - 1] += 1;        
                }
            }
        }

        return result;
    }
}