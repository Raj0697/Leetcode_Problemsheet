public class Solution
{
    public int ConsecutiveNumbersSum(int n)
    {
        int count = 0;
        int k = 1;
        
        // Continue while k * (k-1) / 2 < n
        while (k * (k - 1) / 2 < n)
        {
            // Calculate the remaining part after subtracting the sum of first (k-1) numbers
            int remaining = n - k * (k - 1) / 2;

            // Check if remaining is divisible by k
            if (remaining % k == 0)
            {
                count++;
            }

            k++;
        }

        return count;
    }
}