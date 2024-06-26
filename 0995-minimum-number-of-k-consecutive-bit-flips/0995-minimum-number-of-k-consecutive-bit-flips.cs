public class Solution {
    public int MinKBitFlips(int[] nums, int k) {
        if(nums == null || nums.Length == 0)
            throw new ArgumentException("Invalid Input.");
        
        int n = nums.Length, flipCnt = 0;

        // diff[i]: diffience of total flips between index i and i - 1
        int[] diff = new int[n + 1];
        
        // totalFlip: total flip count before index i
        int totalFlip = 0;
          
        for(int i = 0; i < n; i++)
        {
            // totalFlip + diff[i] = actual flip at index i
            totalFlip += diff[i];
            
            // if num[i] + totalFlip is even, then nums[i] = 0
            // otherwise, nums[i] = 1
            if((nums[i] + totalFlip) % 2 == 0)
            {
                // (i + k - 1) last index where need a flip
                if(i + k - 1 >= n)
                    return -1;
                
                // all the positions within range of [i, i + k - 1] will flip once
                totalFlip++;
                // starting from index (i+k), we should stop flipping, so cancel the flips that shouldn't happen 
                diff[i + k] -= 1;
                
                // flip count
                flipCnt++;
            }
        }

        return flipCnt;
    }
}