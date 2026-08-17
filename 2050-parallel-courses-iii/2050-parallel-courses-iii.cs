public class Solution {
    public int MinimumTime(int n, int[][] relations, int[] time) {
        // Build the graph and calculate indegrees
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        int[] indegrees = new int[n];
        int[] maxTime = new int[n];

        foreach (var relation in relations) {
            int prevCourse = relation[0] - 1;
            int nextCourse = relation[1] - 1;

            if (!graph.ContainsKey(prevCourse))
                graph[prevCourse] = new List<int>();

            graph[prevCourse].Add(nextCourse);
            indegrees[nextCourse]++;
        }

        // Initialize a queue for topological sorting
        Queue<int> queue = new Queue<int>();

        // Add courses with no prerequisites to the queue
        for (int i = 0; i < n; i++) {
            if (indegrees[i] == 0) {
                queue.Enqueue(i);
                maxTime[i] = time[i];
            }
        }

        // Perform topological sorting
        while (queue.Count > 0) {
            int currentCourse = queue.Dequeue();

            if (!graph.ContainsKey(currentCourse))
                continue;

            foreach (var nextCourse in graph[currentCourse]) {
                indegrees[nextCourse]--;
                maxTime[nextCourse] = Math.Max(maxTime[nextCourse], maxTime[currentCourse] + time[nextCourse]);

                if (indegrees[nextCourse] == 0)
                    queue.Enqueue(nextCourse);
            }
        }

        // Find the maximum time taken to complete all courses
        int minTotalTime = 0;
        foreach (int timeTaken in maxTime) {
            minTotalTime = Math.Max(minTotalTime, timeTaken);
        }

        return minTotalTime;
    }
}