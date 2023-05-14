public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums2.Length < nums1.Length) {
            var temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }
        
        var n = nums1.Length;
        var m = nums2.Length;
        
        var start = 0;
        var end = n;
        
        while(start <= end) {
            var blockN = start + (end - start) / 2;
            var blockM = (n + m + 1) / 2 - blockN;
            
            var blockNMin = blockN == 0 ? int.MinValue : nums1[blockN - 1];
            var blockNMax = blockN == n ? int.MaxValue : nums1[blockN];
            var blockMMin = blockM == 0 ? int.MinValue : nums2[blockM - 1];
            var blockMMax = blockM == m ? int.MaxValue : nums2[blockM];
            
            if (blockNMin <= blockMMax && blockMMin <= blockNMax) {
                if ((m + n) % 2 == 1) {
                    return Math.Max(blockNMin, blockMMin);
                }
                else {
                    return (Math.Max(blockNMin, blockMMin) +
                            Math.Min(blockNMax, blockMMax)) / 2.0;
                }
            }
            else if (blockNMin > blockMMax) {
                end = blockN - 1;
            }
            else {
                start = blockN + 1;
            }
        }
        
        throw new Exception();
    }
}