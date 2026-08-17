public class Solution {
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k) {
        long left = -10000000000L, right = 10000000000L;

        while (left < right) {
            long mid = left + (right - left) / 2;
            long count = CountLessEqual(nums1, nums2, mid);

            if (count < k) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }

        return left;
    }
    private long CountLessEqual(int[] nums1, int[] nums2, long target) {
        long count = 0;

        foreach (int a in nums1) {
            if (a == 0) {
                if (target >= 0) {
                    count += nums2.Length;
                }
            }
            else if (a > 0) {
                int low = 0, high = nums2.Length - 1, res = -1;

                while (low <= high) {
                    int mid = (low + high) / 2;
                    if ((long)a * nums2[mid] <= target) {
                        res = mid;
                        low = mid + 1;
                    } else {
                        high = mid - 1;
                    }
                }

                count += res + 1;
            }
            else { // a < 0
                int low = 0, high = nums2.Length - 1, res = nums2.Length;

                while (low <= high) {
                    int mid = (low + high) / 2;
                    if ((long)a * nums2[mid] <= target) {
                        res = mid;
                        high = mid - 1;
                    } else {
                        low = mid + 1;
                    }
                }

                count += nums2.Length - res;
            }
        }

        return count;
    }
}