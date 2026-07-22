public class Solution {
    public int RemoveDuplicates(int[] nums) {
         if (nums.Length < 2) // Check if the array has fewer than 2 elements
    {
        return nums.Length; // Return the length of the array as no duplicates exist
    }
        int k = 2;

for (int i = 2; i < nums.Length; i++)
{
    if (nums[i] != nums[k - 2])
    {
        nums[k] = nums[i];
        k++;
    }
}

return k;
    }
}