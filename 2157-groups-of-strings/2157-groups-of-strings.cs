public class Solution {
    public int[] GroupStrings(string[] words) {
        var maskCount = new Dictionary<int,int>();
        foreach (var w in words) {
            int mask = 0;
            foreach (char c in w) {
                mask |= 1 << (c - 'a');
            }
            if (!maskCount.ContainsKey(mask)) maskCount[mask] = 0;
            maskCount[mask]++;
        }

        var visited = new HashSet<int>();
        int groups = 0, maxGroup = 0;

        foreach (var kv in maskCount) {
            if (!visited.Contains(kv.Key)) {
                groups++;
                maxGroup = Math.Max(maxGroup, Dfs(kv.Key, maskCount, visited));
            }
        }
        return new int[]{groups, maxGroup};
    }

    private int Dfs(int start, Dictionary<int,int> maskCount, HashSet<int> visited) {
        var stack = new Stack<int>();
        stack.Push(start);
        int size = 0;

        while (stack.Count > 0) {
            int node = stack.Pop();
            if (visited.Contains(node)) continue;
            visited.Add(node);
            size += maskCount[node];

            for (int i=0;i<26;i++) {
                if ((node & (1<<i)) != 0) {
                    int neighbor = node ^ (1<<i);
                    if (maskCount.ContainsKey(neighbor) && !visited.Contains(neighbor)) {
                        stack.Push(neighbor);
                    }
                }
            }
            for (int i=0;i<26;i++) {
                if ((node & (1<<i)) == 0) {
                    int neighbor = node | (1<<i);
                    if (maskCount.ContainsKey(neighbor) && !visited.Contains(neighbor)) {
                        stack.Push(neighbor);
                    }
                }
            }
            for (int i=0;i<26;i++) {
                if ((node & (1<<i)) != 0) {
                    for (int j=0;j<26;j++) {
                        if ((node & (1<<j)) == 0) {
                            int neighbor = (node ^ (1<<i)) | (1<<j);
                            if (maskCount.ContainsKey(neighbor) && !visited.Contains(neighbor)) {
                                stack.Push(neighbor);
                            }
                        }
                    }
                }
            }
        }
        return size;
    }
}