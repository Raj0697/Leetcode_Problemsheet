public class Solution {
    // dp array stores the minimum time for completing 'i' laps
    // reach array stores the minimum time to complete the 'i-th' lap using any tire
    private int[] dp = new int[1001];
    private int[] reach = new int[20];
    private int max = 0; // Variable to keep track of the maximum laps we can compute using tires

    public int MinimumFinishTime(int[][] tires, int changeTime, int numLaps) {
        // Step 1: For each tire, calculate the minimum time to complete the x-th lap.
        foreach (var tire in tires) {
            int a = tire[0], b = tire[0]; // a represents the time for the 1st lap, b is used to calculate time for successive laps
            for (int i = 1; i <= numLaps && b < tire[0] + changeTime; i++) {
                // Update the minimum time to reach the i-th lap using this tire
                if (reach[i] == 0 || reach[i] > a) reach[i] = a;
                max = Math.Max(max, i); // Update the maximum lap number we can compute using this tire
                b *= tire[1]; // Update the time for the next lap (multiply by the rate 'r')
                a += b; // Accumulate the time for this lap
            }
        }

        // Step 2: Find the minimum time for completing numLaps using the available tire data
        return Find(changeTime, numLaps) - changeTime; // Subtract changeTime since it should not be counted in the result
    }

    // Step 3: Recursive function to calculate the minimum time to complete 'laps' laps
    private int Find(int time, int laps) {
        // Base case: If no laps are needed, the time is 0
        if (laps == 0) return 0;

        // If the result for 'laps' is already calculated, return it from the dp array
        if (dp[laps] != 0) return dp[laps];

        // Initialize the result to a large number (Integer.MAX_VALUE in Java, int.MaxValue in C#)
        int ret = int.MaxValue;

        // Try completing laps by taking each possible combination of earlier laps
        for (int i = 1; i <= Math.Min(laps, max); i++) {
            ret = Math.Min(ret, time + reach[i] + Find(time, laps - i)); // Minimize the time
        }

        // Store the result in dp[laps] for future reference
        return dp[laps] = ret;
    }
}