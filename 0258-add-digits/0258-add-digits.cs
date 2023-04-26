public class Solution {
    public int AddDigits(int num) {
        if(num == 0)
            return 0;
        int ans = num % 9;
        return ans == 0 ? 9 : ans;
    }
}