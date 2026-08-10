public class Solution {
    public int MaxSizeSlices(int[] slices) {
        int n = slices.Length/3;
        int[] case1 = slices.Take(slices.Length-1).ToArray();
        int[] case2 = slices.Skip(1).ToArray();

        int[,] memo1 = new int[case1.Length +1,n+1];
        int[,] memo2 = new int[case2.Length +1,n+1];

       for(int i =0; i <= case1.Length;i++)
           for(int j =0; j <= n;j++)
              memo1[i,j] = memo2[i,j] = -1;

        int dp1 = Solve(case1,0,n,memo1);
        int dp2 = Solve(case2,0,n,memo2);

        return Math.Max(dp1,dp2);
    }

public int Solve(int[] slices, int i, int k, int[,] memo){
 if(k ==0  || i >= slices.Length) return 0;
 if(memo[i,k] != -1) return memo[i,k];

 int skip = Solve(slices,i+1,k,memo);
 int take = slices[i] + Solve(slices,i+2,k-1,memo);

 return memo[i,k] = Math.Max(skip,take);

    }
}