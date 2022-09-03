class Solution {
    public int[] twoSum(int[] numbers, int target) {
        int start = 0, end = numbers.length - 1;
        while(start < end) {
            int mid = numbers[start] + numbers[end];
            if(mid == target) {
                return new int[]{start+1,end+1};
            }
            if(mid < target){
                start++;
            }
            else {
                end--;
            }
        }
        return new int[]{};
    }
}