public class Solution {
    int MODULO = (int)Math.Pow(10, 9) + 7;
    public int CountSpecialSubsequences(int[] nums) {
        int len = nums.Length;

        int onesCount = 0;
        int zerosCount = 0;
        int twosCount = 0;
        int twosReachableByOnes = 0;
        int onesReachableByZeros = 0;

        for (int i = len - 1; i > -1; i--){
            if (nums[i] == 2){
                twosCount += twosCount + 1;
                twosCount %= MODULO;
            }
            else if (nums[i] == 1){
                onesCount += twosReachableByOnes;
                onesCount %= MODULO;
                onesCount += twosCount;
                onesCount %= MODULO;

                twosReachableByOnes += twosReachableByOnes;
                twosReachableByOnes %= MODULO;
                twosReachableByOnes += twosCount;
                twosReachableByOnes %= MODULO;
            }
            else{
                zerosCount += onesReachableByZeros;
                zerosCount %= MODULO;
                zerosCount += onesCount;
                zerosCount %= MODULO;

                onesReachableByZeros *= 2;
                onesReachableByZeros %= MODULO;
                onesReachableByZeros += onesCount;
                onesReachableByZeros %= MODULO;
            }
        }

        return zerosCount;
    }
}