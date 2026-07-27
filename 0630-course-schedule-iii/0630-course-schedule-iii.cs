public class Solution {
    public int ScheduleCourse(int[][] courses) {
        Array.Sort(courses, (a, b) => a[1].CompareTo(b[1]));

        var maxHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );
        int totalTime = 0;

        foreach (var course in courses) {
            int duration = course[0], lastDay = course[1];
            
            if (totalTime + duration <= lastDay) {
                totalTime += duration;
                maxHeap.Enqueue(duration, duration);
            } 
            else if (maxHeap.Count > 0 && maxHeap.Peek() > duration) {
                totalTime += duration - maxHeap.Dequeue();
                maxHeap.Enqueue(duration, duration);
            }
        }

        return maxHeap.Count;
    }
}