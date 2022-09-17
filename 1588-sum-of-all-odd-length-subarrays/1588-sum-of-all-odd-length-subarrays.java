class Solution {
    public int sumOddLengthSubarrays(int[] arr) {
        int sum = 0;
        for(int i : arr) {
            sum += i;
        }
        // return sum if elements is less than 3 coz there is no more odd numbers other than 1
        if(arr.length < 3)
            return sum;
        
        int len = 3;
        while(len <= arr.length) {
            
            int currSum = 0;
            
            //Since we will be using the sliding window technique here we store the sum of first len number of elements
            for(int i=0;i<len;i++) {
                currSum += arr[i];
            }
            sum+=currSum;
            
            for(int i=len;i<arr.length;i++) {
                currSum = currSum+arr[i]-arr[i-len];
                sum+=currSum;
            }
            
            //Increasing length of subarray in odd terms
            len+=2;
        }
        return sum;
    }
}