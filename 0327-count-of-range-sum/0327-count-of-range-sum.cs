public class Solution {
    int lower, upper;
    long[] preSum;
    long[] temp;
    int res = 0;

    public int CountRangeSum(int[] nums, int lower, int upper) {
        this.lower = lower;
        this.upper = upper;
        preSum = new long[nums.Length + 1];
        temp = new long[nums.Length + 1];

        for (int i = 0; i < nums.Length; i++)
            preSum[i + 1] = preSum[i] + nums[i];

        Sort(preSum, 0, preSum.Length - 1);
        return res;
    }

    public void Sort(long[] nums, int left, int right) {
        if (left >= right) return;

        int mid = left + (right - left) / 2;
        Sort(nums, left, mid);
        Sort(nums, mid + 1, right);
        Merge(nums, left, mid, right);
    }

    public void Merge(long[] nums, int left, int mid, int right) {
        for (int i = left; i <= right; i++)
            temp[i] = nums[i];

        int start = mid + 1;
        int end = mid + 1;

        for (int i = left; i <= mid; i++) {
            while (start <= right && nums[start] - nums[i] < lower)
                start++;
            while (end <= right && nums[end] - nums[i] <= upper)
                end++;
            res += end - start;
        }

        int m = left;
        int n = mid + 1;

        for (int i = left; i <= right; i++) {
            if (m == mid + 1) {
                nums[i] = temp[n++];
            } else if (n == right + 1) {
                nums[i] = temp[m++];
            } else if (temp[m] > temp[n]) {
                nums[i] = temp[n++];
            } else {
                nums[i] = temp[m++];
            }
        }
    }
}