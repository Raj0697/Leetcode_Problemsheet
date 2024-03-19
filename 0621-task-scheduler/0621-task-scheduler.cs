public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        if (n == 0 || tasks == null || tasks.Length == 0)
        {
            return tasks?.Length ?? 0;
        }

        var map = tasks
                .GroupBy(it => it)
                .Select(it => (0, Count: it.Count()))
                .OrderByDescending(it => it.Count);

        var workQueue = new PriorityQueue<int, int>(map, Comparer<int>.Create((l, r) => r - l));
        var idleQueue = new Queue<(int count, int next)>();

        var time = 0;
        while (workQueue.Count > 0 || idleQueue.Any())
        {
            time++;
            if (workQueue.TryDequeue(out _, out var count) && count > 1)
            {
                idleQueue.Enqueue((--count, time + n));
            }

            if (idleQueue.Any() && idleQueue.Peek().next == time)
            {
                workQueue.Enqueue(0, idleQueue.Dequeue().count);
            }
        }

        return time;

    }
}