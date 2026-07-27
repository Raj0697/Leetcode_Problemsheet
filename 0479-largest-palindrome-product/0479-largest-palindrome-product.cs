public class Solution {
    public int LargestPalindrome(int n) {
        if (n == 1) return 9; // special case

        long upper = (long)Math.Pow(10, n) - 1;
        long lower = (long)Math.Pow(10, n - 1);

        for (long left = upper; left >= lower; left--) {
            // Construct palindrome by mirroring left part
            string s = left.ToString();
            string rev = new string(s.Reverse().ToArray());
            long palindrome = long.Parse(s + rev);

            // Check if palindrome can be factored into two n-digit numbers
            for (long a = upper; a * a >= palindrome; a--) {
                if (palindrome % a == 0) {
                    long b = palindrome / a;
                    if (b >= lower && b <= upper) {
                        return (int)(palindrome % 1337);
                    }
                }
            }
        }
        return -1; // should never reach here
    }
}