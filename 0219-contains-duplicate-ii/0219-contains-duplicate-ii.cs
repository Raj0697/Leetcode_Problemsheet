public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary.Add(nums[i], i);
            }
            else
            {
                if (Math.Abs(dictionary[nums[i]] - i) <=k)
                {
                    return true;
                }

                dictionary[nums[i]] = i;
            }
        }

        return false;
    }
}