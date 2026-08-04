public class Solution {
    public int NumberOfCombinations(string num) {
        int[][] dp = new int[num.Length + 1][];
        int[][] lcs = new int[num.Length + 1][];

        for(int i = 0; i <= num.Length; i++)
        {
            dp[i] = new int[num.Length + 1];
        }
        for(int i = 0; i <= num.Length; i++)
        {
            lcs[i] = new int[num.Length + 1];
        }
 
        for(int i = num.Length - 2; i >= 0; i--)
        {
            for(int j = i + 1 ; j < num.Length; j++)
            {
                if(num[i] == num[j])
                {
                    lcs[i][j] = lcs[i + 1][j + 1] + 1;
                }
            }
        }

        for(int i = 0; i < num.Length; i++)
        {
            for(int l = 1; l <= i + 1; l++)
            {
                int j = i - l + 1;
                int temp = 0; 
                
                if(num[j] == '0')
                    temp = 0;
                else if(j == 0)
                    temp = 1;
                else
                {
                    int maxL = 0;
                    if(j < l)
                        maxL = j;
                    else
                    {
                        int ls = lcs[j - l][j];
                        if( ls >= l || (int.Parse(num.Substring(j - l + ls,1)) <
                        int.Parse(num.Substring(j + ls, 1))))
                        {
                            maxL =  l;
                        }
                        else
                        {
                            maxL = l - 1;
                        }
                    }
                    temp += dp[j - 1][maxL];

                }
                
                dp[i][l] = (dp[i][l - 1] + temp) % 1000000007;
               
            }
        }
        return (dp[num.Length - 1][num.Length]);
        
   }
}