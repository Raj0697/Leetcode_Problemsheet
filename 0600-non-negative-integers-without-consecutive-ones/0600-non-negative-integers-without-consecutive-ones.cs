public class Solution {
    public int FindIntegers(int n) {
        int[] f = new int[32];
        f[0] = 1;
        f[1] = 2;

        for(int i = 2; i < f.Length;i++){
            f[i] = f[i-1] + f[i-2];

        }
        int j = 30;
        int sum = 0;
        int prev = 0;

 while( j >= 0){
    if((n & ( 1 << j)) != 0){
        sum += f[j];
        if(prev == 1){
            sum--;
            break;
        }
        prev = 1;
    } else{
        prev = 0;
      
    }
      j--;
 }

      return sum+1;  
    }
}