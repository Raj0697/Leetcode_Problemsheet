public class Solution
{
    public int SplitArray(int[] nums, int m)
    {
        int lo = nums.Max();
        int hi = nums.Sum();
            
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (IsHighEnough(mid)) hi = mid;
            else lo = mid + 1;
        }
        
        return lo;
        
        bool IsHighEnough(int target)
        {
            int sum = 0;
            int count = 1;

            foreach (int n in nums)
            {
                sum += n;
                if (sum > target)
                {
                    sum = n;
                    if (++count > m) return false;
                }
            }

            return true;
        }
    }
}