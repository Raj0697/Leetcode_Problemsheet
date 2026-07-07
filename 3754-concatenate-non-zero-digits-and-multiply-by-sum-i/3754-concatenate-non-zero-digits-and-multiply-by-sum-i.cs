public class Solution
{
    public long SumAndMultiply(int n)
    {
        int sum = 0;
        long newNum =  0;
        
        string numStr = n.ToString();
        for (int i = 0; i < numStr.Length; i++)
        {
            if(numStr[i] - '0' != 0)
            {
                sum += numStr[i] - '0';
                newNum = newNum * 10 + numStr[i] - '0';
            }
        }

        return sum * newNum;
    }
}