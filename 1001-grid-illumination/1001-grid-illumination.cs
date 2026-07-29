public class Solution
{
    public int[] GridIllumination(int n, int[][] lamps, int[][] queries)
    {
        var ans = new int[queries.Length];
        var R = new Dictionary<int,int>();
        var C = new Dictionary<int,int>();
        var D1 = new Dictionary<int,int>();
        var D2 = new Dictionary<int,int>();
        var L = new HashSet<long>();

        for(int i = 0; i<lamps.Length; i++)
        {
            int r = lamps[i][0];
            int c = lamps[i][1];
            if(L.Contains((long)(r*n+c)))
            {
                continue;
            }
            Plus(R,r);
            Plus(C,c);
            Plus(D1,c-r);
            Plus(D2,c+r);
            L.Add((long)(r*n+c));
        }

        for(int i = 0; i<queries.Length; i++)
        {
            int r = queries[i][0];
            int c = queries[i][1];

            if(R.ContainsKey(r) || C.ContainsKey(c) || D1.ContainsKey(c-r) ||
            D2.ContainsKey(c+r))
            {
                ans[i] = 1;
            }
            else
            {
                ans[i] = 0;
            }
            var dir = new List<(int,int)>(){(r,c),(r+1,c),(r-1,c),(r,c+1),(r,c-1)
            ,(r-1,c-1),(r-1,c+1),(r+1,c-1),(r+1,c+1)};
            for(int j = 0; j<9; j++)
            {
                int r1 = dir[j].Item1;
                int c1 = dir[j].Item2;
                long ind = r1*n+c1;
                if(r1<0 || c1<0 || r1 == n || c1 == n)
                {
                    continue;
                }
                if(L.Contains(ind) == false)
                {
                    continue;
                }
                Minus(R,r1);
                Minus(C,c1);
                Minus(D1,c1-r1);
                Minus(D2,c1+r1);
                L.Remove(ind);
            }
        }

        return ans;
    }
    public void Plus(Dictionary<int,int> D, int key)
    {
        if(D.ContainsKey(key))
        {
            D[key]++;
        }
        else
        {
            D.Add(key,1);
        }
    }
    public void Minus(Dictionary<int,int> D, int key)
    {
        if(D.ContainsKey(key))
        {
            D[key]--;
            if(D[key] == 0)
            {
                D.Remove(key);
            }
        }
    }
}