public class Solution
{
    public int MinimumDifference(int[] nums)
    {
        int n = nums.Length;

        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }

        var dict1 = Build(nums, 0, (n - 1) / 2);
        var dict2 = Build(nums, n / 2, n - 1);

        foreach (int key in dict2.Keys)
        {
            dict2[key].Sort();
        }

        int min = int.MaxValue;

        foreach (int count in dict1.Keys)
        {
            foreach (int sum1 in dict1[count])
            {
                if (dict2[n / 2 - count].Count > 0)
                {
                    int target = (sum - 2 * sum1) / 2;

                    int start = 0;
                    int end = dict2[n / 2 - count].Count - 1;

                    int mid;
                    while (start + 1 < end)
                    {
                        mid = start + (end - start) / 2;

                        if (dict2[n / 2 - count][mid] <= target)
                        {
                            start = mid;
                        }
                        else
                        {
                            end = mid;
                        }
                    }

                    int sum2 = dict2[n / 2 - count][start];
                    min = Math.Min(min, Math.Abs(2 * (sum1 + sum2) - sum));

                    sum2 = dict2[n / 2 - count][end];
                    min = Math.Min(min, Math.Abs(2 * (sum1 + sum2) - sum));
                }
            }
        }

        return min;
    }

    private IDictionary<int, List<int>> Build(int[] nums, int l, int r)
    {
        int n = r - l + 1;

        var dict = new Dictionary<int, List<int>>();
        for (int i = 0; i <= n; i++)
        {
            dict.Add(i, new List<int>());
        }

        int count;
        int sum;
        for (int mask = 0; mask < 1 << n; mask++)
        {
            count = 0;
            sum = 0;

            for (int i = 0; i < n; i++)
            {
                if (((mask >> i) & 1) > 0)
                {
                    count++;
                    sum += nums[l + i];
                }
            }

            dict[count].Add(sum);
        }

        return dict;
    }
}