public class Solution {
    public int MaximumRequests(int n, int[][] requests) {
        int m = requests.Length; // Number of requests
        int maxAchievable = 0; // Maximum achievable requests

        // Iterate through all possible combinations of requests using bitmasking
        for (int mask = 0; mask < (1 << m); mask++) {
            int[] buildings = new int[n]; // Array to track the net change in employee transfers for each building

            // Calculate the net change for each request based on the bitmask
            for (int i = 0; i < m; i++) {
                if ((mask & (1 << i)) != 0) {
                    int from = requests[i][0];
                    int to = requests[i][1];
                    buildings[from]--;
                    buildings[to]++;
                }
            }

            // Check if the net change is zero for all buildings
            bool isValid = true;
            for (int j = 0; j < n; j++) {
                if (buildings[j] != 0) {
                    isValid = false;
                    break;
                }
            }

            // Update the maximum achievable requests if the current combination is valid
            if (isValid) {
                int count = CountSetBits(mask);
                maxAchievable = Math.Max(maxAchievable, count);
            }
        }

        return maxAchievable;
    }
    private int CountSetBits(int num) {
        int count = 0;
        while (num > 0) {
            count += num & 1;
            num >>= 1;
        }
        return count;
    }
}