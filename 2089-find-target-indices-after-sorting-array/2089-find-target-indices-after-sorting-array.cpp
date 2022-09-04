class Solution {
public:
    vector<int> targetIndices(vector<int>& nums, int target) {
        sort(nums.begin(),nums.end());
        int f1=0,f2=0;
        int low=0;
        int high=nums.size()-1;
        int fir=0;
        while(low<=high){
         int  mid=low+(high-low)/2;
            
            if(nums[mid]==target){
                fir=mid;
                high=mid-1;
                f1=1;
            }
            else if(nums[mid]<target){
                low=mid+1;
            }
            else{
                high=mid-1;
            }
        }
        
        
        int low1=0;
        int high1=nums.size()-1;
        int last=0;
        while(low1<=high1){
         int   mid1=low1+(high1-low1)/2;
            
            if(nums[mid1]==target){
                last=mid1;
                low1=mid1+1;
                f2=1;
            }
            else if(nums[mid1]<target){
                low1=mid1+1;
            }
            else{
                high1=mid1-1;
            }
        }
        
        vector<int> res;
        
        if(f1!=0 && f2!=0)
        for(int i=fir;i<=last;i++){
            res.push_back(i);
        }
        
        return res;
   }
};

