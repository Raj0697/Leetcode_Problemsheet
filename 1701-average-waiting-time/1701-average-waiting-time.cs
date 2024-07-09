public class Solution {
    public double AverageWaitingTime(int[][] customers) {
        int end = 0;
        double averageWaitingTime = 0;
        
        for (int i=0; i<customers.Length; i++)
        {
            int arrival = customers[i][0], timeToCook = customers[i][1];
            
            if (end < arrival) end = arrival + timeToCook;
            else end += timeToCook;
            
            averageWaitingTime += (end-arrival);
        }
        
        return (averageWaitingTime)/customers.Length;
    }
}