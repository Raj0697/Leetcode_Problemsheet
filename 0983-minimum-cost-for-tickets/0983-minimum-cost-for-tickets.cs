public class Solution {
    int[] daysTravel;
    int[] dp;
    
    public int MincostTickets(int[] days, int[] costs) {
        daysTravel = new int[]{1, 7, 30};
        dp = new int[days.Length];
        Array.Fill(dp, -1);
        return MincostTicketsUtil(days, costs, 0, 0);
    }
    
    private int MincostTicketsUtil(int[] days, int[] costs, int index, int day) {
        if(index >= days.Length)
            return 0;
        
        if(index > 0 && days[index] < day) {
            return MincostTicketsUtil(days, costs, index + 1, day);
        }
        
        if(dp[index] != -1)
            return dp[index];
        
        int cost = int.MaxValue;
        
        for(int i = 0; i < 3; i++) {
            cost = Math.Min(cost, costs[i] + MincostTicketsUtil(days, costs, index + 1,
                                                                days[index] + daysTravel[i]));
        }
        
        dp[index] = cost;
        
        return dp[index];
    }
}