class Solution {
    // Main function to find the target in the Mountain Array
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        int peak = FindPeak(mountainArr);  // Find the peak index
        int result = BinarySearch(mountainArr, target, 0, peak, false);  // Search in ascending part
        return result != -1 ? result : BinarySearch(mountainArr, target, peak + 1, mountainArr.Length() - 1, true); // If not found, search in descending part
    }

    // Binary search with the option for ascending or descending order
    private int BinarySearch(MountainArray arr, int target, int start, int end, bool isDesc) {
        while (start <= end) {
            int mid = (start + end) / 2;
            int midVal = arr.Get(mid);
            if (midVal == target) return mid;
            if (isDesc ? midVal > target : midVal < target) start = mid + 1;
            else end = mid - 1;
        }
        return -1; // Target not found
    }

    // Function to find the peak index using binary search
    private int FindPeak(MountainArray arr) {
        int start = 0, end = arr.Length() - 1;
        while (start < end) {
            int mid = (start + end) / 2;
            if (arr.Get(mid) < arr.Get(mid + 1)) start = mid + 1;
            else end = mid;
        }
        return start; // Peak index
    }
}