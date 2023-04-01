public class Solution {
    public int Search(int[] n, int target) {
        int l=0, r=n.Length-1;
        while(l<=r) {
            int mid = l+(r-l)/2;
            if(n[mid] == target) {
                return mid;
            }
            if(n[mid] > target) {
                r = mid-1;
            }
            else{
                l = mid+1;
            }
        }
        return -1;
    }
}