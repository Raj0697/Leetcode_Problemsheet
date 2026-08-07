public class Solution {
    public int MaximalNetworkRank(int n, int[][] roads) {
         int[] degree = new int[n];
 HashSet<string> roadSet = new HashSet<string>();

 foreach (int[] road in roads)
 {
     degree[road[0]]++;
     degree[road[1]]++;
     roadSet.Add(road[0] + "," + road[1]);
     roadSet.Add(road[1] + "," + road[0]);
 }

 int maxRank = 0;
 for (int i = 0; i < n; i++)
 {
     for (int j = i + 1; j < n; j++)
     {
         int rank = degree[i] + degree[j];
         if (roadSet.Contains(i + "," + j))
         {
             rank--;
         }
         maxRank = Math.Max(maxRank, rank);
     }
 }

 return maxRank;
    }
}