public class Solution {
    public int FindMinMoves(int[] machines) {
        int dress_all = machines.Sum();
        int n = machines.Length;
        if(dress_all%n != 0)
            return -1;
        
        int moves = 0, avg = dress_all/n;
        int curr = 0;
        foreach(int m in machines){
            curr = curr + m - avg;
            moves = Math.Max(moves, Math.Max(Math.Abs(curr), m - avg));
        }
        
        return moves;
    }
}