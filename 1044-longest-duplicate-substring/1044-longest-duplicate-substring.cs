public class Solution {
    public string LongestDupSubstring(string s) {
        return BinarySearch(s);
    }

    private string BinarySearch(string s)
    {
        int start = 1;
        int end = s.Length - 1;
        string result = String.Empty;

        while (start <= end)
        {
            int mid = start + (end - start) / 2; //Window Size

            string temp = CalculateRollingHash(s, mid);

            if (!String.IsNullOrEmpty(temp))
            {
                result = temp;
                start = mid + 1; // increasing the window size
            }
            else
            {
                end = mid - 1; //decreasing the window size
            }
        }

        return result;
    }

    private string CalculateRollingHash(string s, int window)
    {
        long baseVal = 31;
        long mod = (long)(1e9 + 7);

        long hashedVal = 0;
        //Calculating the hashed value for the entire window
        for (int i = 0; i < window; i++)
        {
            hashedVal = (hashedVal * baseVal + (s[i] - 'a' + 1)) % mod;
        }

        long maxPow = 1;

        for (int i = 1; i < window; i++)
        {
            maxPow = (maxPow * baseVal) % mod;
        }

        Dictionary<long, int> mappedHashed = new Dictionary<long, int>();
        mappedHashed.Add(hashedVal, 0);

        for (int i = 1; i + window <= s.Length; i++)
        {
            //Remove first character from hashedValue
            hashedVal = (hashedVal - (s[i - 1] - 'a' + 1) * maxPow) % mod;

            while(hashedVal < 0)
            {
                hashedVal += mod;
            }

            //Add window next char to hashedVal
            hashedVal = (hashedVal * baseVal + s[i + window - 1] - 'a' + 1) % mod;

            if (mappedHashed.ContainsKey(hashedVal))
            {
                int start = mappedHashed[hashedVal];

                string oldStr = s.Substring(start, window);
                string newStr = s.Substring(i, window);

                //To avoid hash collision again checking the substring for the same hashed value
                if (oldStr == newStr)
                    return newStr;
            }

            mappedHashed[hashedVal] = i;
        }

        return String.Empty;
    }
}

/*
s = "banana"
b , ba, ban, an, ana
*/