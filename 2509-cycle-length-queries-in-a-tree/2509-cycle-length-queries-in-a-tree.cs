public class Solution {
    public int[] CycleLengthQueries(int n, int[][] queries) {
        var answer = new int[queries.Length];
        var i = 0;
        foreach (var query in queries)
        {
            (var a, var b) = (query[0], query[1]);
            answer[i++] = distance(a, b);
        }
        return answer;
    }
    
    public int depth(int a)
    {
        var res = 1;
        while (a > 1)
        {
            a >>= 1;
            res++;
        }
        return res;
    }
    
    public int getLca(int a, int b)
    {
        while (a > 1 || b > 1)
        {
           while (b > a)
           {
              b >>= 1;
           }
           
           if (a == b)
           {
               return a;
           }
           
           while (a > b)
           {
               a >>= 1;
           }
           
           if (a == b)
           {
               return a;
           }
        }
        return 1;
    }
    
    public int distance(int a, int b)
    {
        int lca = getLca(a, b);
        return depth(a) + depth(b) - 2 * depth(lca) + 1;
    }
}