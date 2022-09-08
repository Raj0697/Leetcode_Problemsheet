class Solution {
    public int countOdds(int low, int high) {
        int odd = 0;
        while(low <= high) {
            if ((low ^ 1) == low + 1){
            } else{
                odd +=1;
            }
            low++;
        }
        return odd;
    }
}