public class Solution {
    public int FindJudge(int N, int[][] trust) {
        int[] countTrusted = new int[N];
        int[] countTrusters = new int[N];
        foreach (int[] relation in trust) 
        {
            countTrusters[relation[1] - 1]++;
            countTrusted[relation[0] - 1]++;
        }
        for (int i = 0; i < N; ++i) 
        {
            if (countTrusters[i] == N - 1 && countTrusted[i] == 0) 
            {
                return i + 1;
            }    
        }
        return -1;
    }
}