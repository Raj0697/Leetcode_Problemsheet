class Solution {
    public void moveZeroes(int[] nums) {
        //Arrays.sort(nums);
        // bruteforce approach
        // for(int i=0; i<nums.length; i++) {
        //     for(int j=0; j<nums.length - 1; j++) {
        //         if(nums[j] == 0){
        //             int temp = nums[j];
        //             nums[j] = nums[j+1];
        //             nums[j+1] = temp;
        //         }
        //     }
        // }
         int j = 0;
         for(int i = 0; i< nums.length; i++){
            if(nums[i] != 0){
                nums[j] = nums[i];
                j++;
            }
        }
        for(int i = j; i<nums.length; i++){
            nums[i] = 0;
       }
    }
}