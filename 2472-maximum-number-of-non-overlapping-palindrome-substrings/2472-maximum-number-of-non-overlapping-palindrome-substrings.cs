public class Solution {
    public int MaxPalindromes(string s, int k) {
        int[] dp = new int[s.Length];
        dp[k-1] = IsPal(0, k - 1, s);
        if(k < s.Length){
            dp[k] = Math.Max(Math.Max(dp[0] + IsPal(1, k, s), IsPal(0, k, s)), dp[k - 1]);
        }
        for(int i = k + 1; i < dp.Length; i++){
            dp[i] = Math.Max(Math.Max(dp[i - k] + IsPal(i - k + 1, i, s), dp[i - k - 1] + IsPal(i - k, i, s)), dp[i - 1]);
        }
        return dp[^1];
    }

    public int IsPal(int left, int right, string s){
        while(left < right){
            if(s[left] != s[right]){
                return 0;
            }
            left++;
            right--;
        }
        return 1;
    }
}