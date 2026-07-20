public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if (intervals.Length <= 1)
        return 0;
    
        // Sort the intervals based on their end points in ascending order
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        
        int count = 0;
        int end = intervals[0][1];
        
        // Iterate through the sorted intervals
        for (int i = 1; i < intervals.Length; i++) {
            // If the current interval overlaps with the previous one, increment count
            // and update the end point to the minimum end point
            if (intervals[i][0] < end) {
                count++;
            } else {
                end = intervals[i][1];
            }
        }
        
        return count;
    }
}