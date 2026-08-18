public class Solution {
    int[] memo;
    int[] nums;
    int numSlots;

    public int MaximumANDSum(int[] nums, int numSlots) {
        this.memo = new int[1 << (2 * numSlots)];
        this.nums = nums;
        this.numSlots = numSlots;
        return Helper(0, 0);
    }

    // Helper function with numIndex (index of the number) and set (which slots have been filled)
    private int Helper(int numIndex, int set) {
        // Base case: when we've used all numbers
        if (numIndex == nums.Length) return 0;

        // If this state has already been computed, return it (memoized value)
        if (memo[set] > 0) return memo[set] - 1; // subtract 1 since we store max + 1 to avoid -1

        int max = 0;

        // Try placing the current number in any available slot
        for (int i = 0; i < numSlots; i++) {
            // Check if the first half slot is available
            int firstHalfSlot = (set & (1 << i)) == 0 ? i : -1;
            // Check if the second half slot is available
            int secondHalfSlot = (set & (1 << (i + numSlots))) == 0 ? i + numSlots : -1;
            // Choose a slot (first available one)
            int slotChosen = firstHalfSlot > -1 ? firstHalfSlot : secondHalfSlot;

            if (slotChosen < 0) continue; // both slots are used, move on

            int andSum = 0;
            // Calculate AND sum based on the chosen slot
            if (slotChosen >= numSlots) {
                andSum = ((slotChosen - numSlots) + 1) & nums[numIndex];
            } else {
                andSum = (slotChosen + 1) & nums[numIndex];
            }

            // Backtrack: set the slot and recurse with the next number
            max = Math.Max(max, andSum + Helper(numIndex + 1, set | (1 << slotChosen)));
        }

        // Memoize the result (max + 1 to avoid -1)
        memo[set] = max + 1;
        return max;
    }
}