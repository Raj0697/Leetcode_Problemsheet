public class Solution {
    // dp[i] là số cách xoá nhỏ nhất từ 1 đến i
    // dp1[i] là cách xoá nhỏ nhất từ n đến i
    // if(s[i]==0) dp[i]=dp[i-1]
    // else 
    //     if(s[i-1]=='1') dp[i]=dp[i-1]+1;
    //     else dp[i]=dp[i-1]+2
    //
    public int MinimumTime(string s) {
        int n = s.Length;
        var dp = new int[n+1];
        var dp1 = new int[n+1];
       
        var checkFirst = new int[n+1];
        var checkLast = new int[n+1];
        if(s[0]=='1'){
            checkFirst[0]=1;
            dp[0]=1;
        }
        for(int i=1;i<n;i++){
            if(s[i]=='0'){
                dp[i]=dp[i-1];
            }
            else {

                if(checkFirst[i-1]==1) {
                    dp[i]=dp[i-1]+1;
                    checkFirst[i]=1;
                }
                else dp[i]=dp[i-1]+2;
                
                if(i+1<=dp[i]){
                    dp[i]=i+1;
                    checkFirst[i]=1;
                }

            }
           // Console.WriteLine(dp[i] + " " + i);
        } 
        if(s[n-1]=='1'){
            dp1[n-1]=1;
            checkLast[n-1]=1;
        }
        for(int i=n-2;i>=0;i--){
            if(s[i]=='0'){
                dp1[i]=dp1[i+1];
            }
            else {
                if(checkLast[i+1]==1){
                    dp1[i]=dp1[i+1]+1;
                    checkLast[i]=1;
                }
                else dp1[i]=dp1[i+1]+2;
                int cnt = (n-1)-i+1;
                if(cnt<=dp1[i]){
                    dp1[i]=cnt;
                    checkLast[i]=1;
                }
            }
        }
         var ans = Math.Min(dp[n-1],dp1[0]);
         for(int i=0;i<n-1;i++) ans =Math.Min(dp[i]+dp1[i+1],ans);

        return ans;


    }
}