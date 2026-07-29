public class Solution {
    public string LargestMultipleOfThree(int[] digits) {
        var count = new int[10];
        int sum = 0;

        // Count digit frequencies and calculate sum of digits
        foreach (var digit in digits) {
            count[digit]++;
            sum += digit;
        }

        // Calculate remainder of sum when divided by 3
        int remainder = sum % 3;

        // Adjust the count based on the remainder
        if (remainder != 0) {
            if (!RemoveDigits(count, remainder)) {
                RemoveDigits(count, 3 - remainder);
            }
        }

        // Construct the largest number
        var result = new List<char>();
        for (int i = 9; i >= 0; i--) {
            result.AddRange(Enumerable.Repeat((char)(i + '0'), count[i]));
        }

        // Remove leading zeros
        var resultStr = new string(result.ToArray());
        return resultStr.Length > 0 && resultStr[0] == '0' ? "0" : resultStr;
    }

    private bool RemoveDigits(int[] count, int remainder) {
        if (remainder == 1) {
            // Try to remove one digit with remainder 1
            for (int i = 1; i <= 9; i += 3) {
                if (count[i] > 0) {
                    count[i]--;
                    return true;
                }
            }

            // If not possible, try to remove two digits with remainder 2
            int needed = 2;
            for (int i = 2; i <= 8; i += 3) {
                while (count[i] > 0 && needed > 0) {
                    count[i]--;
                    needed--;
                }
                if (needed == 0) return true;
            }
        } else if (remainder == 2) {
            // Try to remove one digit with remainder 2
            for (int i = 2; i <= 8; i += 3) {
                if (count[i] > 0) {
                    count[i]--;
                    return true;
                }
            }

            // If not possible, try to remove two digits with remainder 1
            int needed = 2;
            for (int i = 1; i <= 9; i += 3) {
                while (count[i] > 0 && needed > 0) {
                    count[i]--;
                    needed--;
                }
                if (needed == 0) return true;
            }
        }
        return false;
    }
}