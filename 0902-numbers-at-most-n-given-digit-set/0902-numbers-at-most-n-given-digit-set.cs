public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        string strN = n.ToString();
        int lenN = strN.Length;
        int lenD = digits.Length;
        int result = 0;
        
        // Precompute powers of lenD
        int[] powers = new int[lenN + 1];
        powers[0] = 1;
        for (int i = 1; i <= lenN; i++) {
            powers[i] = powers[i - 1] * lenD;
        }

        // Step 1: Count numbers with fewer digits than n
        for (int i = 1; i < lenN; i++) {
            result += powers[i];  // lenD^i numbers can be formed with i digits
        }

        // Step 2: Count numbers with the same number of digits as n
        for (int i = 0; i < lenN; i++) {
            bool hasSamePrefix = false;
            foreach (var digit in digits) {
                if (digit[0] < strN[i]) {
                    result += powers[lenN - i - 1];  // If digit is smaller, we can form valid numbers
                } else if (digit[0] == strN[i]) {
                    hasSamePrefix = true;  // Continue to the next digit
                    break;  // No need to check further as the prefix matches
                } else {
                    break;  // All larger digits won't work, stop checking
                }
            }

            if (!hasSamePrefix) {
                return result;  // If no matching prefix, stop further exploration
            }
        }

        // Add 1 for the number n itself, since it's valid
        return result + 1;
    }
}