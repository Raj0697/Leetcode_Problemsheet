public class Solution {
    public int SubarraySum(int[] nums, int k) {
        // ps = <int sum of the current prefix, count>
        var ps = new Dictionary<int, int>();
        ps[0] = 1;
        
        int sum = 0;
        int cnt = 0;
        int len = nums.Length;
        
        for (int i = 0; i < len; ++i) {
            sum = sum + nums[i];
            
            // See if the sum - what you're looking for exists in the map. The map represents the element sums seen so far
            var prefixLookup = sum - k;
            if (ps.ContainsKey(prefixLookup)) {
                cnt += ps[prefixLookup];
            }
            
            // Add current sum frequency for later lookup
            ps[sum] = ps.ContainsKey(sum) ? ps[sum] + 1 : 1;
        }
        
        return cnt;
    }
}