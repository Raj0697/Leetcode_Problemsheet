public class Solution {
    public int MinTrioDegree(int n, int[][] edges) {
        var adjList = new List<int>[n+1];

        for(int i=0; i<=n; i++){
            adjList[i] = new List<int>();
        }

        foreach(var edge in edges){
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        var result = int.MaxValue;
        //Identifying trio and calculating degree of trio
        for(int i=1; i<=n; i++){
            for(int j=i+1; j<=n; j++){
                for(int k=j+1; k<=n; k++){
                    if(adjList[i].Contains(j) && adjList[j].Contains(k) && adjList[k].Contains(i)){
                        result = Math.Min(result,(adjList[i].Count + adjList[j].Count + adjList[k].Count) - 6); // rremoving the trio edge contributing to each node's degree
                    }
                }
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}