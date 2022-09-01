class Solution {
    public int find(int[]nums,int x){ // to find numbers greater than or equal to x
        int count = 0;
        for(int i:nums)
        {
            if(i>=x)
                count++;
        }
      return count;
    }
   
    public int specialArray(int[] nums) {
        int start = 1,end = nums.length;
        
        while(start<=end){
            int x = start + (end-start)/2;
			
             if(x == find(nums,x)) 
                 return x;
            
             if(find(nums,x) > x)
                 start  = x+1;
              else
                  end = x-1;
        }
        
    return -1;
    }
}