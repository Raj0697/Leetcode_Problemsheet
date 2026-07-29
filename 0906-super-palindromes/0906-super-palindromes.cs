public class Solution {
    public int SuperpalindromesInRange(string left, string right)
{
    long L = long.Parse(left);
    long R = long.Parse(right);
    int MAGIC = 100000;
    int ans = 0;

    // count odd length
    for (int k = 1; k < MAGIC; ++k)
    {
        StringBuilder sb = new StringBuilder(k.ToString());

        for (int i = sb.Length - 2; i >= 0; --i)
            sb.Append(sb[i]);

        long v = long.Parse(sb.ToString());
        v *= v;

        if (v > R) break;
        if (v >= L && IsPalindrome(v)) ans++;
    }

    // count even length
    for (int k = 1; k < MAGIC; ++k)
    {
        StringBuilder sb = new StringBuilder(k.ToString());

        for (int i = sb.Length - 1; i >= 0; --i)
            sb.Append(sb[i]);

        long v = long.Parse(sb.ToString());
        v *= v;

        if (v > R) break;
        if (v >= L && IsPalindrome(v)) ans++;
    }

    return ans;
}

public bool IsPalindrome(long x)
{
    return x == Reverse(x);
}

public long Reverse(long x)
{
    long ans = 0;
    while (x > 0)
    {
        ans = 10 * ans + x % 10;
        x /= 10;
    }

    return ans;
}
}