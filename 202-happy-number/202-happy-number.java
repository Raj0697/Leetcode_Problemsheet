class Solution {
    boolean res = false;
    public boolean isHappy(int n) {
        int num = 0, sum = 0;
        while(n > 0) {
            num = n % 10;
            sum += num*num;
            n /= 10;
        }
        if(sum != 1 && sum != 4)
            isHappy(sum);
        else if(sum == 1)
            res = true;
        return res;
    }
}