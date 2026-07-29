public class Solution {
    public int NumBusesToDestination(int[][] routes, int source, int target) {
        if (source == target) return 0;

        Dictionary<int, List<int>> stopToRoutes = new Dictionary<int, List<int>>();

        for (int i = 0; i < routes.Length; i++) {
            foreach (int stop in routes[i]) {
                if (!stopToRoutes.ContainsKey(stop)) {
                    stopToRoutes[stop] = new List<int>();
                }
                stopToRoutes[stop].Add(i);
            }
        }

        Queue<int> queue = new Queue<int>();
        HashSet<int> visitedStops = new HashSet<int>();
        HashSet<int> visitedRoutes = new HashSet<int>();

        queue.Enqueue(source);
        visitedStops.Add(source);

        int buses = 0;

        while (queue.Count > 0) {
            int stopsAtThisLevel = queue.Count;

            for (int i = 0; i < stopsAtThisLevel; i++) {
                int currentStop = queue.Dequeue();

                List<int> busesAtStop = stopToRoutes.ContainsKey(currentStop) ? stopToRoutes[currentStop] : new List<int>();

                foreach (int bus in busesAtStop) {
                    if (visitedRoutes.Contains(bus)) continue;

                    visitedRoutes.Add(bus);

                    foreach (int nextStop in routes[bus]) {
                        if (visitedStops.Contains(nextStop)) continue;

                        visitedStops.Add(nextStop);

                        if (nextStop == target) return buses + 1;

                        queue.Enqueue(nextStop);
                    }
                }
            }

            buses++;
        }

        return -1;
    }
}