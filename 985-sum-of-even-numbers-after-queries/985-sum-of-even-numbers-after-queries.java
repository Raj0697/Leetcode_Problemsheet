class Solution {
    public int[] sumEvenAfterQueries(int[] nums, int[][] queries) {
        int sum = 0;
        for(int i : nums){
            if((i & 1) != 1)
                sum += i;
        }
        int q = queries.length;
        int[] res = new int[q];
        for(int i=0; i<q; i++) {
            int val = queries[i][0], pos = queries[i][1];
            if((nums[pos] & 1) != 1) { sum -= nums[pos]; } // subtract old value
            nums[pos] += val;
            if((nums[pos] & 1) != 1) { sum += nums[pos]; }
            res[i] = sum;
        }
        return res;
    }
}