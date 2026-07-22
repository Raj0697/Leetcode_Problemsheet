public class Solution 
{
    public IList<string> SummaryRanges(int[] nums) 
    {
        List<string> ranges = new List<string>();
        if (nums.Length == 0)
            return ranges;
            
        int first = nums[0];
        int prev = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == prev + 1)
                prev++;
            else
            {
                AddToRanges(ranges, first, prev);
                first = nums[i];
                prev = nums[i];
            }
        }

        AddToRanges(ranges, first, prev);
        return ranges;
    }

    public void AddToRanges(List<string> ranges, int first, int prev)
    {
        if (first == prev)
            ranges.Add($"{first}");
        else
            ranges.Add($"{first}->{prev}");
    }
}