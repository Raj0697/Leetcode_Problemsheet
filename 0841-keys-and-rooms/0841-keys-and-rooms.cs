public class Solution 
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var visited = new bool[rooms.Count];
        Dfs(room: 0);
        return visited.All(v => v);

        void Dfs(int room)
        {
            if (visited[room]) return;
            
            visited[room] = true;

            foreach (int key in rooms[room])
            {
                Dfs(key);
            }
        }
    }
}