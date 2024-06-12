public class Solution {
    public void SortColors(int[] nums) {
        int r,w,b;
        r = w = b = 0;

        foreach(var i in nums)
        {
            if(i == 0) r++;
            else if(i == 1) w++;
            else b++;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if(r > 0)
            {
                nums[i] = 0;
                r--;
            }
            else if(w > 0)
            {
                nums[i] = 1;
                w--;
            }
            else
                nums[i] = 2;
        }
    }
}