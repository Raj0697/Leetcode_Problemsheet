class Solution {
    Set<Integer> set = new HashSet<>();
    public int getCommon(int[] nums1, int[] nums2) {
        for(int val : nums1) set.add(val);
        for(int val : nums2) {
            if(set.contains(val))
                return val;
        }
        return -1;
    }
}