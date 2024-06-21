public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int n = customers.Length;
        int satisfiedCustomers = 0;
        
        // Step 1: Calculate initially satisfied customers
        for (int i = 0; i < n; i++) {
            if (grumpy[i] == 0) {
                satisfiedCustomers += customers[i];
            }
        }

        // Step 2: Compute prefix sums for grumpy customers
        int[] grumpyPrefixSum = new int[n + 1];
        for (int i = 0; i < n; i++) {
            grumpyPrefixSum[i + 1] = grumpyPrefixSum[i];
            if (grumpy[i] == 1) {
                grumpyPrefixSum[i + 1] += customers[i];
            }
        }

        // Step 3: Find the maximum number of additional satisfied customers using prefix sums
        int maxAdditionalSatisfied = 0;
        for (int i = 0; i <= n - minutes; i++) {
            int end = i + minutes;
            int additionalSatisfied = grumpyPrefixSum[end] - grumpyPrefixSum[i];
            maxAdditionalSatisfied = Math.Max(maxAdditionalSatisfied, additionalSatisfied);
        }

        // Step 4: Return the total satisfied customers
        return satisfiedCustomers + maxAdditionalSatisfied;
    }
}