public class Solution {
    public int HIndex(int[] citations) {
        int n = citations.Length;
        int left = 0;
        int right = n-1;
       

       while(left <= right){
        int mid = left + (right-left)/2;
         int h = n-mid;

         if(citations[mid] >= h){
              right = mid-1;
         }else{
           left = mid+1;
          }
       }

      return n-left;

    }
}