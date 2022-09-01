/* The isBadVersion API is defined in the parent class VersionControl.
      boolean isBadVersion(int version); */

public class Solution extends VersionControl {
    public int firstBadVersion(int n) {
        int low = 0, end = n, temp = 0;
        while(low <= end)
        {
            int mid = low + (end - low) / 2;
            if(isBadVersion(mid))
            {
                temp = mid;
                end = mid - 1;
            }
            else{
                low = mid + 1;
            }
        }
        return temp;
    }
}