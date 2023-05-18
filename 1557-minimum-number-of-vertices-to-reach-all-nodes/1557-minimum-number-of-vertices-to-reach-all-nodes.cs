public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        //To store vertices which has incoming edge..
        HashSet<int> verticesWithInEdge = new HashSet<int>();
        foreach (var edge in edges)
        {
            verticesWithInEdge.Add(edge[1]);
        }

        //To store vertices which has no incoming edge (has only outgoing edge)
        List<int> onlyOutGoing = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (!verticesWithInEdge.Contains(i))
                onlyOutGoing.Add(i);
        }

        return onlyOutGoing;
    }
}