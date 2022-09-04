class Solution {
    public int arrangeCoins(int n) {
    //     if (n < 0) {
    //         throw new IllegalArgumentException("Input Number is invalid. Only positive numbers are allowed");
    //     }
    //     return (int) (Math.sqrt(2 * (long) n + 0.25) - 0.5);
    // }
        
        long s = 0, e = n;
        while(s <= e){
        long mid = s + (e-s)/2;
        long k = mid*(mid+1)/2;
        
        if(k == n){
            return (int)mid;
        }
        else if (k > n){
            e = mid - 1;
        }
        else{
            s = mid + 1;
        }
    }
    return (int)e;
}
}