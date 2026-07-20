public class Solution {
    public int NumDistinct(string s, string t) {
        int[] arr=new int[t.Length+1];
        arr[0]=1;
        for(int i=1;i<=s.Length;i++){
            for(int j=t.Length;j>=1;j--){
                if(s[i-1]==t[j-1]){
                    arr[j]+=arr[j-1];
                }
            }
        }
        return arr[t.Length];

    }
}