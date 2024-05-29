public class Solution {
    public int NumSteps(string s) {
        int num = 0;
        int index = s.Length - 1;
        while (s[index] == '0') {
            num++;
            index--;
        }
        
        int ones = 0;
        while (index >= 0) {
            if (s[index] == '0') {
                num += ones + 1;
                ones = 1;
            }
            else {
                ones++;
            }
            index--;
        }
        
        return num + ((ones > 1) ? ones + 1 : 0);
    }
}