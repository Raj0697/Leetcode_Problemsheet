public class Solution
{
    public int[][] SubsetsWithDup(int[] nums)
    {
        var buckets = new int[21];
        int valuesCount = 0, resultLength = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            var value = nums[i] + 10;

            if (buckets[value] == 0)
                valuesCount++;
            buckets[value]++;
        }

        var values = new (int value, int count)[valuesCount];

        for (int i = 20; i >= 0; i--)
            if (buckets[i] != 0)
            {
                values[--valuesCount] = (i - 10, buckets[i]);
                resultLength *= buckets[i] + 1;
                buckets[i] = valuesCount + 1;
            }

        var result = new int[resultLength][];
        var currentSubset = new List<int>(nums.Length);
        var index = 0;

        while (true)
        {
            if (index < values.Length)
            {
                for ((int value, int count) = values[index]; count > 0; count--)
                    currentSubset.Add(value);

                index++;
            }
            else
            {
                result[--resultLength] = [.. currentSubset];

                if (resultLength == 0) break;

                index = buckets[currentSubset[^1] + 10];
                currentSubset.RemoveAt(currentSubset.Count - 1);
            }
        }

        return result;
    }
}