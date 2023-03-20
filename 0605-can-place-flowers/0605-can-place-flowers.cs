public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        // int count=0;
        // for(int i=0; i<flowerbed.Length && count < n; i++) {
        //     int next = (i == flowerbed.Length - 1) ? 0 : flowerbed[i+1];
        //     int prev = (i == 0) ? 0 : flowerbed[i-1];
        //     if(next == 0 && prev == 0) {
        //         flowerbed[i] = 1;
        //         count++;
        //     }
        // }
        // return count == n;
        var current = 0;
        for(var i = 0; i <= flowerbed.Length; i++) {
            if (i < flowerbed.Length && flowerbed[i] == 0) {
                current++;
                if (i == 0) current++;
                if (i == flowerbed.Length - 1) current++;
            } else {
                n -= (current - 1) / 2;
                if (n <= 0) return true;
                current = 0;
            }
        }
        return false;
    }
}