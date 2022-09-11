class Solution {
    public int arraySign(int[] nums) {
        int prod = 1;
        for(int i=0; i<nums.length; i++) {
            if(nums[i] < 0)
                prod *= -1;
            else if(nums[i] > 0)
                prod *= 1;
            else
                return 0;
        }
        return prod;
    }
    // public int signFunc(int t) {
    //     if(t < 0)
    //         return -1;
    //     if(t > 0)
    //         return 1;
    //     else
    //         return 0;
    //     //return (t != 0 && t > 0) ? 1 : 0;
    // }
}