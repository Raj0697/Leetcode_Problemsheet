public class Solution {
    public int MaxProduct(int[] nums) {
        int ans = nums[0];
        int n = nums.Count();
        int p = 1, q=1;
        for(int i=0;i<n;i++){
		    // reset to 1 when the product becomes zero
            p = (p==0?1:p)*nums[i];
            q = (q==0?1:q)*nums[n-1-i];
            ans = Math.Max(ans,Math.Max(p,q));
        }
        
        return ans;
    }
}