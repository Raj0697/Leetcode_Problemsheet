public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {
        int timeRequired = tickets[k], n = tickets.Length;
        for(int i=0; i<n; i++){
            // here we are not taking the case of i==k, because it is already added in the timeRequired.
            if(i<k){
             timeRequired += Math.Min(tickets[i], tickets[k]);
            }
            else if(i > k){
                timeRequired += Math.Min(tickets[i], tickets[k]-1);
            }
        }
        return timeRequired;
    }
}