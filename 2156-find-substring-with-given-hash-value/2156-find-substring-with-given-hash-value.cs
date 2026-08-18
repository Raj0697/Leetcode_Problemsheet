public class Solution {
    public string SubStrHash(string s, int power, int modulo, int k, int hashValue) {
        // Convert parameters to the proper types (to match the Rust logic)
        ulong mod = (ulong)modulo;
        ulong p = (ulong)power;
        int kLen = k;
        ulong hashVal = (ulong)hashValue;

        // Convert the string to a byte array
        byte[] sBytes = System.Text.Encoding.ASCII.GetBytes(s);

        // Initialize variables
        ulong tmp = 0;
        ulong r = 1;
        int res = s.Length;

        // Calculate the hash for the last k characters
        for (int i = s.Length - kLen; i < s.Length; i++) {
            tmp += (ulong)(sBytes[i] - 96) * r;
            tmp %= mod;
            r = (r * p) % mod;
        }

        // Check if the last k characters match the hashValue
        if (tmp == hashVal) {
            res = s.Length - kLen;
        }

        // Sliding window: Update the hash and check other substrings
        for (int i = s.Length - kLen - 1; i >= 0; i--) {
            tmp = tmp * p % mod + mod;
            tmp -= (ulong)(sBytes[i + kLen] - 96) * r % mod;
            tmp = (tmp + (ulong)(sBytes[i] - 96)) % mod;

            // If the hash matches the hashValue, update the result
            if (tmp == hashVal) {
                res = i;
            }
        }

        // Return the substring corresponding to the result
        if (res <= s.Length - kLen) {
            return s.Substring(res, kLen);
        } else {
            return "";
        }
    }
}