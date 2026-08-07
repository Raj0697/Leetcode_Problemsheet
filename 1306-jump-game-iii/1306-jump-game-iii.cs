public class Solution {
    public bool CanReach(int[] arr, int start) {
        int length = arr.Length;
        bool[] visited = new bool[length];

        bool DFS(int start)
        {
            if (start < 0 || start >= length || visited[start])
            {
                return false;
            }

            if (arr[start] == 0)
            {
                return true;
            }

            visited[start] = true;

            if (DFS(start - arr[start]) || DFS(start + arr[start]))
            {
                return true;
            }

            visited[start] = false;

            return false;
        }

        return DFS(start);
    }
}