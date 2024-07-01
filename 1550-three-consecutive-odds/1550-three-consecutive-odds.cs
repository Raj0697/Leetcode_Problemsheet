public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        /*for(int i = 2; i < arr.Length; i++) {
            // any number & 1 == 1 --> odd number
            if((arr[i] & 1) == 1 &&  (arr[i-1] & 1) == 1 && (arr[i-2] & 1) == 1) {
                return true;
            }
        }*/
        for (int i = 0, cnt = 0; i < arr.Length; i++) {
            if (arr[i] % 2 == 0) cnt = 0;
            else if (++cnt == 3) return true;
        }
        return false;
        
    }
}