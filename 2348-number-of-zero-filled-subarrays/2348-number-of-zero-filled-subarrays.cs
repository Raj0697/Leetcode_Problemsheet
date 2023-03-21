public class Solution {
    public long ZeroFilledSubarray(int[] nums) {
        long cnt = 0, zeroSubarraysEndingAtCurrentIndex = 0;
        foreach(int n in nums) {
            if(n == 0) {
            cnt += ++zeroSubarraysEndingAtCurrentIndex;
            }else {
                zeroSubarraysEndingAtCurrentIndex = 0;
            }
        }
        return cnt;
    }
}