public class Solution {
    public int FindMinimumTime(int[][] tasks) {
        // Sort tasks by their end time
        Array.Sort(tasks, (a, b) => a[1].CompareTo(b[1]));
        bool[] used = new bool[2001]; // Covers time from 0 to 2000
        
        foreach (var task in tasks) {
            int start = task[0], end = task[1], duration = task[2];
            int usedTime = 0;
            
            // Calculate how much of the duration is already covered
            for (int i = start; i <= end; i++) {
                if (used[i]) usedTime++;
            }
            
            int remaining = duration - usedTime;
            if (remaining <= 0) continue;
            
            // Fill from the end backward to cover remaining duration
            int ptr = end;
            while (remaining > 0 && ptr >= start) {
                if (!used[ptr]) {
                    used[ptr] = true;
                    remaining--;
                }
                ptr--;
            }
        }
        
        // Count all used times
        int total = 0;
        foreach (bool b in used) {
            if (b) total++;
        }
        return total;
    }
}