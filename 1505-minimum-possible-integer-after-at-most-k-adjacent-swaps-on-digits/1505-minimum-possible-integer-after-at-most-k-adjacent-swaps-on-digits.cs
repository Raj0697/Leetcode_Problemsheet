public class Solution {
    public string MinInteger(string num, int k) {
        char[] digits = num.ToCharArray();
        int n = digits.Length;

        for (int i = 0; i < n && k > 0; i++) {
            // Find the smallest digit within the next k positions
            int minIndex = i;
            for (int j = i + 1; j < n && j <= i + k; j++) {
                if (digits[j] < digits[minIndex]) {
                    minIndex = j;
                }
            }

            // If a smaller digit is found, move it to the front
            if (minIndex != i) {
                // The number of swaps needed to move the minIndex to the current position
                int swapsNeeded = minIndex - i;
                if (swapsNeeded <= k) {
                    // Perform the swaps
                    char minChar = digits[minIndex];
                    for (int j = minIndex; j > i; j--) {
                        digits[j] = digits[j - 1];
                    }
                    digits[i] = minChar;
                    
                    // Decrease k by the number of swaps performed
                    k -= swapsNeeded;
                }
            }
        }

        return new string(digits);
    }
}