class Solution {
    Set<Integer> set = new HashSet<>();
    public int[] intersection(int[] nums1, int[] nums2) {
        Arrays.sort(nums1);
        Arrays.sort(nums2);
        int i=0, j=0;
        while(i<nums1.length && j<nums2.length) {
            if(nums1[i] < nums2[j]) i++;
            else if(nums1[i] > nums2[j]) j++;
            else {
                set.add(nums1[i]);
                i++;
                j++;
            }
        }
        // for(int val : nums1){
        //     if(binary(nums2, val))
        //         set.add(val);
        // }
        int[] result = new int[set.size()];
        int k=0;
        for(int n : set) {
            result[k++] = n;
        }
        return result;
    }
    
    // public static boolean binary(int[] nums, int k) {
    //     int l=0, h=nums.length-1;
    //     while(l<=h) {
    //         int mid = l+(h-l)/2;
    //         if(nums[mid] == k) return true;
    //         if(nums[mid] < k) l=mid+1;
    //         else h = mid-1;
    //     }
    //     return false;
    // }
}