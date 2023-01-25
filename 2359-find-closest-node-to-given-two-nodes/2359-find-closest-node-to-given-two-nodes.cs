public class Solution {
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        Dictionary<int, int> d1 = new (), d2 = new ();

        int iterIndex = node1, distance = 0;
        while (iterIndex != -1 && !d1.ContainsKey(iterIndex))
        {
            d1[iterIndex] = distance++;
            iterIndex = edges[iterIndex];
        }

        int ansIndex = int.MaxValue, ansDistance = int.MaxValue;
        iterIndex = node2;
        distance = 0;
        while (iterIndex != -1 && !d2.ContainsKey(iterIndex))
        {
            d2[iterIndex] = distance++;

            if (d1.ContainsKey(iterIndex))
            {
                int m = Math.Max(d1[iterIndex], d2[iterIndex]);
                if (m < ansDistance || (m == ansDistance && iterIndex < ansIndex))
                {
                    ansIndex = iterIndex;
                    ansDistance = m;
                }
            }
            iterIndex = edges[iterIndex];
        }

        if (ansIndex == int.MaxValue)
            return -1;
        return ansIndex;
    }
}