public class Solution {
    public string AbbreviateProduct(int a, int b) {
        double value = 1.0;
        int countZeros = 0, digitShift = 0;
        long remainder = 1;
        
        for (int num = a; num <= b; num++) {
            value *= num;
            while (value >= 1) 
            {
                value /= 10;
                digitShift++;
            }

            remainder *= num;
            while (remainder % 10 == 0) 
            {
                countZeros++;
                remainder /= 10;
            }

            if (remainder > (long)Math.Pow(10, 14))
                remainder %= (long)Math.Pow(10, 14);
        }

        if (digitShift - countZeros <= 10) 
            return ((long)(value * Math.Pow(10, digitShift - countZeros) + 0.5)).ToString() + "e" + countZeros;
        else 
        {
            string prefix = ((long)(value * 100000)).ToString();
            string suffix = (remainder % 100000).ToString().PadLeft(5, '0');
            return prefix + "..." + suffix + "e" + countZeros;
        }
    }
}