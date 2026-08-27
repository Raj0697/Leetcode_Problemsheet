public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        if (numerator == 0) return "0";

        StringBuilder sb = new StringBuilder();
        if ((numerator < 0) ^ (denominator < 0)) sb.Append("-");

        long num = Math.Abs((long) numerator);
        long den = Math.Abs((long) denominator);

        sb.Append(num / den);
        long rem = num % den;
        if (rem == 0) return sb.ToString();

        sb.Append(".");
        Dictionary<long, int> seen = new Dictionary<long, int>();
        while (rem != 0) {
            if (seen.ContainsKey(rem)) {
                int pos = seen[rem];
                sb.Insert(pos, "(");
                sb.Append(")");
                break;
            }
            seen[rem] = sb.Length;
            rem *= 10;
            sb.Append(rem / den);
            rem %= den;
        }
        return sb.ToString();
    }
}