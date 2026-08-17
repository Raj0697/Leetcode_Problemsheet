public class Solution {
    public int MaximumInvitations(int[] favorite) {
        
        int n = favorite.Length;
        bool[] visited = new bool[n];
        int[] indegree = new int[n];
        int[] maxChainLength = new int[n];

        foreach(var num in favorite)
        {
            indegree[num]++;
        }

        Queue<int> queue = new Queue<int>();
        for(int i = 0; i < n; i++)
        {
            if(indegree[i] == 0)
            {
                queue.Enqueue(i);
                visited[i] = true;
            }
        }

        // Fill in maxChainLength using topologic sort
        while(queue.Count > 0)
        {
            var curr = queue.Dequeue();
            var fav = favorite[curr];
            maxChainLength[fav] = Math.Max(maxChainLength[fav], maxChainLength[curr] + 1);

            indegree[fav]--;
            if(indegree[fav] == 0)
            {
                queue.Enqueue(fav);
                visited[fav] = true;
            }
        }

        // Detect cycle
        int maxClosedCycleLength = 0, pairedChainSum = 0;
        for(int i = 0; i < n; i++)
        {
            if(!visited[i] && indegree[i] == 1)
            {
                int length = 0, curr = i;
                do
                {
                    visited[curr] = true;
                    curr = favorite[curr];
                    length++;
                }while(curr != i);

        
                if(length == 2)
                {
                    // 2-cycle case: two nodes form a cycle
                    pairedChainSum += 2 + maxChainLength[i] + maxChainLength[favorite[i]];
                }
                else
                {
                    // closed cycle.
                    maxClosedCycleLength = Math.Max(maxClosedCycleLength, length);
                }
            } 
        }

        return Math.Max(maxClosedCycleLength, pairedChainSum);
    }
}