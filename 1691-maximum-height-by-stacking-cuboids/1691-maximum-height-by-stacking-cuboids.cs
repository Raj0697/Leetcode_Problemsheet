public class Solution {
    public int MaxHeight(int[][] cuboids) {
        // sort inner array
        int n = cuboids.Length;
        int maxH = 0;
        for(int i = 0; i<n; i++){
            Array.Sort(cuboids[i]);
        }
        Array.Sort(cuboids, (a,b)=>{
            if(a[0] != b[0]) return a[0]-b[0];
            if(a[1] != b[1]) return a[1]-b[1];
            return a[2]-b[2];
        });

        int[] dp = new int[n];
        dp[0] = cuboids[0][2];
        for(int i = 0; i<n; i++){
            dp[i] = cuboids[i][2];
            for(int j = i-1; j>=0; j--){
                if(IsSmaller(cuboids[i], cuboids[j])){
                    dp[i] = Math.Max(dp[i], cuboids[i][2] + dp[j]);
                }
            }
            maxH = Math.Max(maxH, dp[i]);
        }
        return maxH;
    }


    public static bool IsSmaller(int[] top, int[] bottom){
    for(int i = 0; i < 3; i++){
        if(top[i] < bottom[i]){
            return false;
        }
    }
    return true;
        }
}