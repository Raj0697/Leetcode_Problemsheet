public class Solution 
{
    private List<int> a = new List<int>(), b = new List<int>(), ans = new List<int>();
    private Dictionary<string, int> gridMap = new Dictionary<string, int>();

    private void Helper(int n, int index, int[][] grid) 
    {
        if (ans.Count > 0) return;

        if (index == n) 
        {
            string aKey = string.Join(",", a);
            if (gridMap.ContainsKey(aKey) && ans.Count == 0) 
            {
                ans.Add(gridMap[aKey] - 1);

                for (int i = 0; i < grid.Length; i++) 
                {
                    bool isValid = true;

                    for (int j = 0; j < grid[i].Length; j++) 
                    {
                        if (a[j] == 1 && grid[i][j] == 1) 
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid) 
                    {
                        ans.Add(gridMap[string.Join(",", grid[i])] - 1);
                        break;
                    }
                }

                if (ans.Count == 1) ans.Clear();
            }

            return;
        }

        a[index] = 0;
        b[index] = 1;
        Helper(n, index + 1, grid);

        a[index] = 1;
        b[index] = 0;
        Helper(n, index + 1, grid);
    }

    public List<int> GoodSubsetofBinaryMatrix(int[][] grid) 
    {
        // Map each row of the grid to its index + 1 using a string representation for keys
        for (int i = 0; i < grid.Length; i++) 
        {
            string key = string.Join(",", grid[i]);
            gridMap[key] = i + 1;
        }

        // Check if any row is entirely zeros; if found, return its index immediately
        for (int i = 0; i < grid.Length; i++) 
        {
            if (grid[i].All(cell => cell == 0)) 
            {
                return new List<int> { i };
            }
        }

        // Initialize vectors 'a' and 'b' with zeros
        a = Enumerable.Repeat(0, grid[0].Length).ToList();
        b = Enumerable.Repeat(0, grid[0].Length).ToList();

        // Recursively search for a good subset
        Helper(grid[0].Length, 0, grid);

        // Sort the resulting indices and return
        ans.Sort();
        return ans;
    }
}