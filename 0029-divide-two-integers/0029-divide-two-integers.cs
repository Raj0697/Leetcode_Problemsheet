public class Solution {
    public int Divide(int dividend, int divisor) {
        if (divisor == 1) { return dividend; }
        if (divisor == -1 &&  dividend == int.MinValue) { return int.MaxValue; }
        if (dividend == divisor) { return 1; }
        if (dividend == 0 || divisor == int.MinValue) { return 0; }
        
        bool isNeg = (dividend < 0 && divisor > 0) ||  (dividend > 0 && divisor < 0);
        
        int count = 0;
        if (dividend == int.MinValue)
        {
            if (divisor < 0) {  dividend -= divisor; } else { dividend += divisor; }
            count++;
        }
        
        int dvd = (dividend < 0)? -dividend: dividend;
        int dvs = (divisor < 0)? -divisor: divisor;
         
        int temp = dvs;
        int i = 0;
        while(temp > 0)
        {
           i++;
           temp>>=1;
        }   
        
        int multi=31-i;
        
        while (dvd >= dvs)
        {   
            temp = dvs;
            while((temp << multi) > dvd) { multi--; }
                 
            dvd -= temp << multi;
            count += 1 << multi; 
        }  
                  
        if (isNeg) { count = -count; }
        
        return count;
    }
}